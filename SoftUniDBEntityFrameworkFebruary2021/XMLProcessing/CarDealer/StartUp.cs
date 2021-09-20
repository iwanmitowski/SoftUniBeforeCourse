using System;
using AutoMapper;
using CarDealer.Data;
using System.IO;
using System.Xml.Serialization;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;
using System.Collections.Generic;
using CarDealer.Dtos.Export;
using System.Text;
using AutoMapper.QueryableExtensions;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static IConfigurationProvider config;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //DON'T make it: var config = new MapperConfig !!!!!

            config = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);

            //P01
            var suppliersInput = File.ReadAllText("../../../Datasets/suppliers.xml");
            var resultSuppliersInput = ImportSuppliers(context, suppliersInput);

            //P02
            var partsInput = File.ReadAllText("../../../Datasets/parts.xml");
            var resultPartsInput = ImportParts(context, partsInput);

            //P03
            var carsInput = File.ReadAllText("../../../Datasets/cars.xml");
            var resultCarsInput = ImportCars(context, carsInput);

            //P04
            var customersInput = File.ReadAllText("../../../Datasets/customers.xml");
            var resultCustomersInput = ImportCustomers(context, customersInput);

            //P05
            var salesInput = File.ReadAllText("../../../Datasets/sales.xml");
            var resultSalesInput = ImportSales(context, salesInput);

            //P06
            var resultCarsWithDistance = GetCarsWithDistance(context);

            //P07
            var resultBmwCars = GetCarsFromMakeBmw(context);

            //P08
            var resultLocalSuppliers = GetLocalSuppliers(context);

            //P09
            var resultCarsWithTheirParts = GetCarsWithTheirListOfParts(context);

            //P10
            var resultTotalSalesByCustomer = GetTotalSalesByCustomer(context);

            //P11
            var resultSalesWithAppliedDiscount = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(resultSalesWithAppliedDiscount);
        }

        //P11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .ProjectTo<ExportSaleWithAppliedDiscountDTO>(config)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSaleWithAppliedDiscountDTO[]), new XmlRootAttribute("customers"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, sales);

            return writer.ToString().Trim();
        }

        //P10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                   .ProjectTo<ExportTotalSalesByCustomerDTO>(config)
                   .Where(x=>x.BoughtCars > 0)
                   .OrderByDescending(c => c.SpentMoney)
                   .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDTO[]), new XmlRootAttribute("customers"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, customers);

            return writer.ToString().Trim();
        }

        //P09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                   .ProjectTo<ExportCarWithITsListOfPartsDTO>(config)
                   .OrderByDescending(x => x.TravelledDistance)
                   .ThenBy(x => x.Model)
                   .Take(5)
                   .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithITsListOfPartsDTO[]), new XmlRootAttribute("cars"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, cars);


            return writer.ToString().Trim();
        }

        //P08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .ProjectTo<ExportLocalSupplierDTO>(config)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDTO[]), new XmlRootAttribute("suppliers"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, suppliers);


            return writer.ToString().Trim();
        }

        //P07
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .ProjectTo<ExportBmwCarDTO>(config)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportBmwCarDTO[]), new XmlRootAttribute("cars"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, cars);


            return writer.ToString().Trim();
        }

        //P06
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .ProjectTo<ExportCarWithDistanceDTO>(config)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDTO[]), new XmlRootAttribute("cars"));

            using var writer = new StringWriter();

            xmlSerializer.Serialize(writer, cars);


            return writer.ToString().Trim();
        }
        //P05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDTO[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportSaleDTO[])xmlSerializer.Deserialize(reader);

            var sales = mapper.Map<Sale[]>(deserialized)
                .Where(x => context.Cars.Any(c => c.Id == x.CarId)).ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        //P04
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDTO[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportCustomerDTO[])xmlSerializer.Deserialize(reader);

            var customers = mapper.Map<Customer[]>(deserialized);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        //P03
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarDTO[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportCarDTO[])xmlSerializer.Deserialize(reader);

            List<Car> cars = new List<Car>();

            foreach (var car in deserialized)
            {
                var currentCar = mapper.Map<Car>(car);

                foreach (var partId in car.Parts.Select(x => x.Id).Distinct())
                {
                    currentCar.PartCars.Add(new PartCar()
                    {
                        PartId = partId,
                    });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        //P02
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartDTO[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportPartDTO[])xmlSerializer.Deserialize(reader);

            var parts = mapper.Map<Part[]>(deserialized).ToList().Where(x => x.SupplierId <= 31).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        //P01
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSupplierDTO[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportSupplierDTO[])xmlSerializer.Deserialize(reader);

            var suppliers = mapper.Map<Supplier[]>(deserialized);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
    }
}