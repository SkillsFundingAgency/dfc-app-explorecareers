using DFC.App.ExploreCareers.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface ICacheReloadService
    {
        Task Reload(CancellationToken stoppingToken);

        Task<IList<JobCategory>?> GetSummaryListAsync();

        Task ProcessSummaryListAsync(IList<JobCategory> summaryList, CancellationToken stoppingToken);

        Task GetAndSaveItemAsync(JobCategory item, CancellationToken stoppingToken);

        Task DeleteStaleItemsAsync(List<ContentPageModel> staleItems, CancellationToken stoppingToken);

        Task DeleteStaleCacheEntriesAsync(IList<JobCategory> summaryList, CancellationToken stoppingToken);
    }
}