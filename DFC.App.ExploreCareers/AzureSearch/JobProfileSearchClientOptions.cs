using DFC.App.ExploreCareers.Data.Models;

namespace DFC.App.ExploreCareers.AzureSearch
{
    public class JobProfileSearchClientOptions : ClientOptionsModel
    {
        public int PageSize { get; set; } = 10;
    }
}
