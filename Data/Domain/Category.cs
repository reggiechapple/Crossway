using System.Collections.Generic;

namespace Crossways.Data.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ForProduct { get; set; } = false;
        public bool ForPost { get; set; } = false;
        public long ParentId { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<ProductCategory> Products { get; set; } = new List<ProductCategory>();
        public ICollection<PostCategory> Posts { get; set; } = new List<PostCategory>();
    }
}