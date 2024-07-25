using DfE.NCS.Framework.Cache.Interface;
using DfE.NCS.Framework.Core.Constants;
using DfE.NCS.Framework.Core.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;

namespace DFC.App.ExploreCareers.Services
{
    /// <summary>
    /// Default Preview Handler implementation.
    /// </summary>
    public class PreviewHandler : ICmsPreviewHandler
    {
        /// <summary>
        /// The HTTP context.
        /// </summary>
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<PreviewHandler> _logger;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// The cache.
        /// </summary>
        private readonly ICacheService _cache;

        /// <summary>
        /// The is cache enabled.
        /// </summary>
        private readonly bool _isCacheEnabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCmsPreviewHandler"/> class.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="cache">The cache.</param>
        public PreviewHandler(IHttpContextAccessor httpContext, IConfiguration config, ILogger<PreviewHandler> logger, ICacheService cache)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public string GetGraphQLStatus()
        {
            if (IsPreivewMode())
            {
                return NcsGraphQLStatus.Latest;
            }
            else
            {
                return NcsGraphQLStatus.Published;
            }
        }

        public bool IsPreivewMode()
        {
            return false;
        }

        /// <inheritdoc/>
        public bool IsValidPreviewRequest(string cipherText)
        {
            string text = DecryptString(cipherText);
            string[] splitItems = text.Split(_config[ConfigKeys.PreviewCipherTextSeparator]);
            if (splitItems.Length != 3 ||
                !splitItems[1].Equals(_config[ConfigKeys.PreviewCipherTextPrefix], StringComparison.InvariantCulture) ||
                !long.TryParse(splitItems[0], out var validFromTick) ||
                !long.TryParse(splitItems[2], out var expiryTick))
            {
                _logger.LogWarning("Invalid cipherText request received for the preview mode {cipherText}", cipherText);
                return false;
            }

            var validFrom = new DateTime(validFromTick);
            var expiry = new DateTime(expiryTick);

            if (validFrom > expiry || expiry < DateTime.UtcNow)
            {
                _logger.LogWarning("CipherText token received for the preview mode is not within the expected datetime range {cipherText}", cipherText);
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool SetupPreviewModeCookie(string data)
        {
            if (IsValidPreviewRequest(data))
            {
                AddPreviewModeCookie();
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public void RemovePreviewModeCookie()
        {
            _httpContext?.HttpContext?.Response.Cookies.Delete(_config[ConfigKeys.PreviewCookieName] ?? throw new ArgumentNullException(ConfigKeys.PreviewCookieName));
        }

        /// <summary>
        /// Adds the preview mode cookie.
        /// </summary>
        private void AddPreviewModeCookie()
        {
            if (!long.TryParse(_config[ConfigKeys.PreviewCookieExpirySeconds], out var cookieExpirySeconds))
            {
                _logger.LogWarning($"{ConfigKeys.PreviewCookieExpirySeconds} has invalid value setting it to default value of 3600 seconds.");
                cookieExpirySeconds = 3600;
            }

            var expiryDatetime = DateTime.Now.AddSeconds(cookieExpirySeconds);
            var cacheExpiry = TimeSpan.FromSeconds(cookieExpirySeconds);
            var cookieOptions = new CookieOptions()
            {
                Secure = true,
                Expires = DateTime.Now.AddSeconds(cookieExpirySeconds),
                Path = "/",
            };
            Guid id = Guid.NewGuid();
            if (_isCacheEnabled)
            {
                _ = _cache.SaveEntity(id.ToString(), expiryDatetime.Ticks.ToString(), cacheExpiry);
            }

            _httpContext?.HttpContext?.Response.Cookies.Append(_config[ConfigKeys.PreviewCookieName] ?? throw new ArgumentNullException(ConfigKeys.PreviewCookieName), EncryptString(id.ToString()), cookieOptions);
        }

        private string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(_config[ConfigKeys.PreviewEncryptionKey] ?? throw new NullReferenceException(ConfigKeys.PreviewEncryptionKey));
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using MemoryStream memoryStream = new();
                using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new(cryptoStream))
                {
                    streamWriter.Write(plainText);
                }

                array = memoryStream.ToArray();
            }

            return Convert.ToBase64String(array);
        }

        private string DecryptString(string cipherText)
        {
            try
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);

                using Aes aes = Aes.Create();
                aes.Key = Encoding.UTF8.GetBytes(_config[ConfigKeys.PreviewEncryptionKey] ?? throw new NullReferenceException(ConfigKeys.PreviewEncryptionKey));
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using MemoryStream memoryStream = new(buffer);
                using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
                using StreamReader streamReader = new(cryptoStream);
                return streamReader.ReadToEnd();
            }
            catch (Exception ex) when (ex is CryptographicException or FormatException)
            {
                _logger.LogError(ex, "Error occured while decrypting the text");
                return string.Empty;
            }
        }

    }
}
