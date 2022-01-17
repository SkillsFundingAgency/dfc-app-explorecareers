using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using DFC.App.ExploreCareers.Data.Models.ContentModels;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface ICacheReloadService
    {
        Task<HttpStatusCode> ProcessContentAsync(Uri url, CancellationToken stoppingToken = default);

        Task Reload(CancellationToken stoppingToken);
        bool TryValidateModel(JobCategoryContentItemModel? contentItemModel);
    }
}
