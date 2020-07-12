using AutoMapper;
using ProductsTestTask.Models;
using ProductsTestTask.ViewModels;
using System.Linq;

namespace ProductsTestTask.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(
                o => o.Categories, 
                opts => opts.MapFrom(src => src.Categories
                                    .Select(c => new CategoryViewModel { Id = c.CategoryId, Name = c.Category.Name})));

            CreateMap<AddProductViewModel, Product>().ForMember(o => o.Categories, opts => opts.Ignore());
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
