using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace SMS.webapp.Services
{
    public interface IRepositoryService<TEntity,IModel>where TEntity : class,new() where IModel : class
    {
        Task<IEnumerable<IModel>>GetAllAsync(CancellationToken cancellationToken);
        Task<IModel>InsertAsync(IModel model,CancellationToken cancellationToken);
        Task<IModel> UpdateAsync(int Id,IModel model,CancellationToken cancellationToken);
        Task<IModel>DeleteAsync(int Id,CancellationToken cancellationToken);
        Task<IModel>GetByIdAsync(int Id,CancellationToken cancellationToken);
        Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    }
}
