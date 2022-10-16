using HMZ.Service.DTOs.Queries;
using HMZ.Service.Services.CategoryServices;
using HMZ.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace HMZ.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAll();
            return View(categories);
        }
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddCategory(CategoryQuery categoryQuery)
        {
            if (ModelState.IsValid)
            {
                var result = await categoryService.Create(categoryQuery);
                if (result > 0)
                {
                    return Json(new { statusCode = 200, message = "Category added successfully" });
                }
            }
            return Json(new { statusCode = 203, message = "Add Fail" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}