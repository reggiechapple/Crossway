using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crossways.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetById(long id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(long id);
    }
}