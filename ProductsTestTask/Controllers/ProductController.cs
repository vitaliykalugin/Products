using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsTestTask.Models;
using ProductsTestTask.Services.Interfaces;
using ProductsTestTask.ViewModels;

namespace ProductsTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IProductCategoryService _productCategoryService;

        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService,
            IProductCategoryService productCategoryService,
            IMapper mapper)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get()
        {
            var products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(await _productService.GetAllAsync());
            return Ok(products);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody]AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<AddProductViewModel, Product>(model);
                var addedProduct = await _productService.InsertAsync(product);

                if (model.Categories != null)
                {
                    var categories = _mapper.Map<IEnumerable<CategoryViewModel>, IEnumerable<Category>>(model.Categories);
                    await _productCategoryService.InsertRangeAsync(addedProduct, categories);
                }

                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
