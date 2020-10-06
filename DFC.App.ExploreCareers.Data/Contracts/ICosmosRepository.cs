using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using DFC.App.ExploreCareers.Data.Models;
using DFC.Compui.Cosmos.Contracts;

namespace DFC.App.ExploreCareers.Data.Contracts
{
    public interface ICosmosRepository<T>
        where T : class, IContentPageModel
    {
        Task<bool> PingAsync();

        Task<T?> GetAsync(Expression<Func<T, bool>> where);

        Task<IEnumerable<T?>?> GetListAsync(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>?> GetAllAsync();

        Task<HttpStatusCode> UpsertAsync(T model);

        Task<HttpStatusCode> DeleteAsync(Guid documentId);

        Task<HttpStatusCode> DeleteAllAsync();
    }
}