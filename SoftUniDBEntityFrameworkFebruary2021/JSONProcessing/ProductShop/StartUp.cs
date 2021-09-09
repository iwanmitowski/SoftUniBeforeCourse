using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;
        public static IConfigurationProvider config;
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            config = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();

            });

            mapper = new Mapper(config);

            //P02
            var inputUsers = File.ReadAllText("../../../Datasets/users.json");
            var resultUsers = ImportUsers(context, inputUsers);

            //P03
            var inputProducts = File.ReadAllText("../../../Datasets/products.json");
            var resultProducts = ImportProducts(context, inputProducts);

            //P04
            var inputCategories = File.ReadAllText("../../../Datasets/categories.json");
            var resultCategories = ImportCategories(context, inputCategories);

            //P05
            var inputCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            var resultCategoriesProducts = ImportCategoryProducts(context, inputCategoriesProducts);

            //P06
            var resultProductsInRange = GetProductsInRange(context);

            //P07
            var resultSuccessfullySoldProducts = GetSoldProducts(context);

            //P08
            var resultCategoriesByProductsCount = GetCategoriesByProductsCount(context);

            //P09
            var resultExportUsersAndProducts = GetUsersWithProducts(context);

            Console.WriteLine(resultExportUsersAndProducts);
        }

        //P09
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new
                {
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = x.ProductsSold
                    .Where(ps => ps.Buyer != null)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price.ToString("F2"),
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.SoldProducts.Count())
                .ToList();

            var jsonObj = new
            {
                UsersCount = users.Count,
                Users = users,
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
            };

            var json = JsonConvert.SerializeObject(jsonObj, settings);

            return json;
        }

        //P08
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var products = context.Categories
                .ProjectTo<CategoriesByProductsCountDTO>(config)
                .ToList();

            var json = JsonConvert.SerializeObject(products.OrderByDescending(x => x.ProductsCount), Formatting.Indented);

            return json;
        }

        //P07
        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                .Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .Select(u => new SuccessfullySoldProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold.Select(ps => new SuccessfullySoldProductsBuyerDTO()
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName,
                    })
                    .ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName);

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //P06
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                   .Where(p => p.Price >= 500 && p.Price <= 1000)
                   .ProjectTo<ProductInRangeDTO>(config)
                   .OrderBy(p => p.Price)
                   .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        //P05
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(input);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        //P04
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);
            var categories = mapper.Map<IEnumerable<Category>>(input);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //P03
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(input);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //P02
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(input);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}