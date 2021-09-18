using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Castle.Core.Configuration.Xml;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;
        public static IConfigurationProvider config;

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            config = new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //P01
            var usersInput = File.ReadAllText("../../../Datasets/users.xml");
            var resultUsersInput = ImportUsers(context, usersInput);

            //P02
            var productsInput = File.ReadAllText("../../../Datasets/products.xml");
            var resultProductsInput = ImportProducts(context, productsInput);

            //P03
            var categoriesInput = File.ReadAllText("../../../Datasets/categories.xml");
            var resultCategoriesInput = ImportCategories(context, categoriesInput);

            //P04
            var categoriesProductsInput = File.ReadAllText("../../../Datasets/categories-products.xml");
            var resultCategoriesProductsInput = ImportCategoryProducts(context, categoriesProductsInput);

            //P05
            var resultProductsInRange = GetProductsInRange(context);

            //P06
            var resultSoldProducts = GetSoldProducts(context);

            //P07
            var resultCategoriesByProductCount = GetCategoriesByProductsCount(context);

            //P08
            //var resultUsersWithProducts = GetUsersWithProducts(context); TODO

            //Console.WriteLine(resultUsersWithProducts);
        }

        ////P08 TODO
        //public static string GetUsersWithProducts(ProductShopContext context)
        //{
        //    var users = context.Users
        //         .Where(x => x.ProductsSold.Any())
        //         .ProjectTo<ExportUserAndProductsDTO>(config)
        //         .OrderByDescending(x => x.SoldProducts.Count)
        //         .ThenBy(x => x.LastName)
        //         .Take(10)
        //         .ToArray();

        //    var container = new ExportUserAndProductContainerDTO()
        //    {
        //        Users = users,
        //    };

        //    var xmlSerializer = new XmlSerializer(typeof(ExportUserAndProductContainerDTO), new XmlRootAttribute("Users"));

        //    using var textWriter = new StringWriter();

        //    xmlSerializer.Serialize(textWriter, container);

        //    return textWriter.ToString().Trim();
        //}

        //P07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .ProjectTo<ExportCategoryByProductCountDTO>(config)
                .OrderByDescending(x => x.Count)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductCountDTO[]), new XmlRootAttribute("Category"));

            using var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, categories);

            return textWriter.ToString().Trim();
        }

        //P06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .ProjectTo<ExportUserAndSoldProductsDTO>(config)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Take(5)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserAndSoldProductsDTO[]), new XmlRootAttribute("Users"));

            using var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, users);

            return textWriter.ToString().Trim();
        }

        //P05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ExportProductInRangeDTO>(config)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDTO[]), new XmlRootAttribute("Products"));

            using var textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, products);

            return textWriter.ToString().Trim();
        }

        //P04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportCategoryProductDTO[])xmlSerializer.Deserialize(reader);

            var categoryProducts = mapper.Map<CategoryProduct[]>(deserialized);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //P03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportCategoryDTO[])xmlSerializer.Deserialize(reader);

            var categories = mapper.Map<Category[]>(deserialized);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //P02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDTO[]), new XmlRootAttribute("Products"));

            using var reader = new StringReader(inputXml);

            var ids = context.Users.Select(x => x.Id).ToList();

            var deserialized = (ImportProductDTO[])xmlSerializer.Deserialize(reader);

            var products = mapper.Map<Product[]>(deserialized).Where(x => ids.Contains(x.SellerId)).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }


        //P01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDTO[]), new XmlRootAttribute("Users"));

            using var reader = new StringReader(inputXml);

            var deserialized = (ImportUserDTO[])xmlSerializer.Deserialize(reader);

            var users = mapper.Map<User[]>(deserialized);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}