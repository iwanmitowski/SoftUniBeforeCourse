using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;
using System.Xml;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            this.CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(x => x.BuyerFullName, y => y.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));
            this.CreateMap<User, ExportUserAndSoldProductsDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold)); // Automatically mapps Product to SoldproductDTO
            this.CreateMap<Category, ExportCategoryByProductCountDTO>()
                .ForMember(x => x.AveragePrice, y => y.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(x => x.Count, y => y.MapFrom(s => s.CategoryProducts.Count()))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price)));
            this.CreateMap<ExportSoldProductDTO, ExportProductDTO>();
            this.CreateMap<User, ExportUserAndProductsDTO>()
                 .ForMember(x => x.SoldProducts.SoldProducts, y => y.MapFrom(i => i));

        }
    }
}
