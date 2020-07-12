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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Get()
        {
            var products = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(await _categoryService.GetAllAsync());
            return Ok(products);
        }
    }
}