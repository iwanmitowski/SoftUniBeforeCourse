using System;
using AutoMapper;
using CarDealer.Data;
using System.IO;
using System.Xml.Serialization;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;
using System.Collections.Generic;

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

            var config = new MapperConfiguration(config =>
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

            Console.WriteLine(resultSalesInput);
        }

        //P05
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSaleDTO[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportSaleDTO[])xmlSerializer.Deserialize(reader);

            var sales = mapper.Map<Sale[]>(deserialized)
                .Where(x=> context.Cars.Any(c=>c.Id == x.CarId)).ToList();

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