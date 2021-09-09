using AutoMapper;
using ProductShop.DTOs;
using ProductShop.DTOs;
using ProductShop.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();


            this.CreateMap<Product, ProductInRangeDTO>()
                .ForMember(x => x.Seller, y => y.MapFrom(s => s.Seller.FirstName + " " + s.Seller.LastName));

            this.CreateMap<Category, CategoriesByProductsCountDTO>()
                .ForMember(x => x.ProductsCount, y => y.MapFrom(s => s.CategoryProducts.Select(x => x.Product).Count()))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Select(x => x.Product.Price).Average().ToString("F2")))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts.Select(x => x.Product.Price).Sum().ToString("F2")));
        }
    }
}
