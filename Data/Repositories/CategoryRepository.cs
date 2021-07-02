using System.Linq;
using System.Threading.Tasks;
using Crossways.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Crossways.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Category> GetCoolestCategory()
        {
            return await GetAll()
                .OrderByDescending(c => c.Name)
                .FirstOrDefaultAsync();
        }
    }
}