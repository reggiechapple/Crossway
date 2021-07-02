using System.Threading.Tasks;
using Crossways.Data.Domain;

namespace Crossways.Data.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> GetCoolestCategory();
    }
}