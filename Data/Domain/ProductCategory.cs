namespace Crossways.Data.Domain
{
    public class ProductCategory
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}