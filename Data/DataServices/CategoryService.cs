using Crossways.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crossways.Data.DataServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUrlHelper _urlHelper;
        
        public CategoryService(ICategoryRepository repository, IUrlHelper urlHelper)
        {
            _repository = repository;
            _urlHelper = urlHelper;
        }
    }
}