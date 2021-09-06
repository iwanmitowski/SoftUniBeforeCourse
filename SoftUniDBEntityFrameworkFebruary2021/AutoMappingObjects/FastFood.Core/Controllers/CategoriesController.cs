namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            var category = mapper.Map<Category>(model);
            this.context.Add(category);
            this.context.SaveChanges();

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            var categories = context.Categories
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }
    }
}
