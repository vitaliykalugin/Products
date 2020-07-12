using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsTestTask.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
