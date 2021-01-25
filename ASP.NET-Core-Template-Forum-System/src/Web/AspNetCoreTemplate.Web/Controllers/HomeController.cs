namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {

        /* 1. private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
        this.db = db;
        } */

        /* private readonly IDeletableEntityRepository<Category> categoriesRepository;

         public HomeController(IDeletableEntityRepository<Category> categoriesRepository)
         {
             this.categoriesRepository = categoriesRepository;
         } */

        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            /* 1. var categories = this.db.Categories.Select(x => new IndexCategoryViewModel
             {
                 Description = x.Description,
                 ImageUrl = x.ImageUrl,
                 Name = x.Name,
                 Title = x.Title,
             }).ToList(); */

            /* 2. var categories = this.categoriesRepository.All ().Select(x => new IndexCategoryViewModel
             {
                 Description = x.Description,
                 ImageUrl = x.ImageUrl,
                 Name = x.Name,
                 Title = x.Title,
             }).ToList(); */

            /* var categories = this.categoriesRepository.All()
                .To<IndexCategoryViewModel>()
                .ToList(); */

            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>();

            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
