using System.Collections.Generic;

namespace Crossways.Data.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
        
    }
}