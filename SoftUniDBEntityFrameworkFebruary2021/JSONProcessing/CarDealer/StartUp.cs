using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.ImportDTOs;
using CarDealer.Models;
using Newtonsoft.Json;

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

            config = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(config);

            //P01
            var suppliersInput = File.ReadAllText("../../../Datasets/suppliers.json");
            var resultImportSuppliers = ImportSuppliers(context, suppliersInput);

            //P02
            var partsInput = File.ReadAllText("../../../Datasets/parts.json");
            var resultImportParts = ImportParts(context, partsInput);

            //P03
            var carsInput = File.ReadAllText("../../../Datasets/cars.json");
            var resultImportCars = ImportCars(context, carsInput);

            //P04
            var customersInput = File.ReadAllText("../../../Datasets/customers.json");
            var resultImportCustomers = ImportCustomers(context, customersInput);

            //P05
            var salesInput = File.ReadAllText("../../../Datasets/sales.json");
            var resultImportSales = ImportSales(context, salesInput);

            //P06
            var resultOrderedCustomers = GetOrderedCustomers(context);

            //P07
            var resultToyotaCars = GetCarsFromMakeToyota(context);

            //P08
            var resultLocalSuppliers = GetLocalSuppliers(context);

            //P09
            var resultCarsWithParts = GetCarsWithTheirListOfParts(context);

            //P10
            var resultTotalSalesByCustomer = GetTotalSalesByCustomer(context);

            //P11
            var resultSalesWithAppliedDiscount = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(resultSalesWithAppliedDiscount);
        }

        //P11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Take(10).Select(x => new
            {
                Car = new
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance
                },
                CustomerName = x.Customer.Name,
                Discount = x.Discount.ToString("F2"),
                Price = x.Car.PartCars.Select(x => x.Part.Price).Sum().ToString("F2"),
                PriceWithoutDiscount = 
                    (x.Car.PartCars.Select(x => x.Part.Price).Sum() * (1 - x.Discount / 100)).ToString("F2"),
            });

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        //P10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .ToList()
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Select(x => x.Car.PartCars.Select(x => x.Part.Price).Sum()).Sum(),
                })
                .OrderByDescending(x => x.SpentMoney)
                .OrderByDescending(x => x.BoughtCars);

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //P09
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(x => new
            {
                Car = new
                {
                    x.Make,
                    x.Model,
                    x.TravelledDistance,
                },
                Parts = x.PartCars
                .Where(y => y.CarId == x.Id)
                .Select(z => z.Part)
                .Select(z => new
                {
                    Name = z.Name,
                    Price = z.Price.ToString("F2"),
                })
                .ToList(),
            }).ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //P08
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .ProjectTo<LocalSuppliersDTO>(config)
                .ToList();

            var json = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return json;
        }

        //P07
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ProjectTo<ToyotaCarDTO>(config)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //P06
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ProjectTo<ExportCustomerDTO>(config)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //P05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<ImportSaleDTO>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(input);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //P04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<ImportCustomerDTO>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(input);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);

            var cars = new List<Car>();

            //Mapping -> foreach -> Filling List with the needed item, filling item's collection with another foreach

            foreach (var car in input)
            {
                var currentCar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                cars.Add(currentCar);
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //P02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<ImportPartDTO>>(inputJson);

            var supplierIds = context.Suppliers.Select(x => x.Id).ToArray();

            var parts = mapper.Map<IEnumerable<Part>>(input.Where(x => supplierIds.Contains(x.SupplierId)));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //P01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierDTO>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(input);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
    }
}