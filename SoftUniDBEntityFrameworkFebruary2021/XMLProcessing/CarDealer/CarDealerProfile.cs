using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;
using System.Xml;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<ImportPartDTO, Part>();
            this.CreateMap<ImportCarDTO, Car>();
            this.CreateMap<ImportCustomerDTO, Customer>();
            this.CreateMap<ImportSaleDTO, Sale>();

            this.CreateMap<Car, ExportCarWithDistanceDTO>();
            this.CreateMap<Car, ExportBmwCarDTO>();
            this.CreateMap<Supplier, ExportLocalSupplierDTO>();
            this.CreateMap<Part, ExportPartInfoDTO>();
            this.CreateMap<Car, ExportCarWithITsListOfPartsDTO>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.Select(x => x.Part).OrderByDescending(x => x.Price)));
            this.CreateMap<Customer, ExportTotalSalesByCustomerDTO>()
                .ForMember(x => x.BoughtCars, y => y.MapFrom(s => s.Sales.Count()))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales.SelectMany(sl => sl.Car.PartCars).Sum(x => x.Part.Price)));
            this.CreateMap<Car, ExportCarInfoDTO>();
            this.CreateMap<Sale, ExportSaleWithAppliedDiscountDTO>()
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Car.PartCars.Sum(x => x.Part.Price)))
                .ForMember(x => x.PriceWithDiscount, y => y.MapFrom(s => s.Car.PartCars.Sum(x => x.Part.Price) * (1 - s.Discount / 100)));
        }
    }
}
