using ProductsTestTask.Models.Interfaces;
using System.Collections.Generic;

namespace ProductsTestTask.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
    }
}
