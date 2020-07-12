using ProductsTestTask.Models.Interfaces;

namespace ProductsTestTask.Models
{
    public class ProductCategory : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }
    }
}
