using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.DTO.ImportDTOs;
using CarDealer.Models;

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

            this.CreateMap<Customer, ExportCustomerDTO>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(s => s.BirthDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)));
            this.CreateMap<Car, ToyotaCarDTO>();
            this.CreateMap<Supplier, LocalSuppliersDTO>();

        }
    }
}
