using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Net;
using System.Net.Mime;

namespace DFC.App.ExploreCareers.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult NegotiateContentResult(this Controller controller, object? viewModel, object? dataModel = null, string ViewName = "")
        {
            if (controller == null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            if (controller.Request.Headers.Keys.Contains(HeaderNames.Accept))
            {
                var acceptHeaders = controller.Request.Headers[HeaderNames.Accept].ToString().Split(';');

                foreach (var acceptHeader in acceptHeaders)
                {
                    var items = acceptHeader.Split(',');

                    if (items.Contains(MediaTypeNames.Application.Json, StringComparer.OrdinalIgnoreCase))
                    {
                        return controller.Ok(dataModel ?? viewModel);
                    }

                    if (items.Contains(MediaTypeNames.Text.Html, StringComparer.OrdinalIgnoreCase) || items.Contains("*/*"))
                    { 
                        return string.IsNullOrEmpty(ViewName) ? controller.View(viewModel) : controller.View(ViewName, viewModel);
                    }
                }
            }

            return controller.StatusCode((int)HttpStatusCode.NotAcceptable);
        }
    }
}
