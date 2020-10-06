using System;
using System.Net;
using System.Threading.Tasks;
using DFC.Compui.Cosmos.Contracts;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface IEventMessageService<TModel>
        where TModel : class, IDocumentModel
    {
        Task<HttpStatusCode> CreateOrUpdateAsync(TModel? upsertDocumentModel);

        Task<HttpStatusCode> DeleteAsync(Guid id);

        Task<HttpStatusCode> DeleteAllAsync();
    }
}