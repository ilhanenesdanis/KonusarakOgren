using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;

namespace WebUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;

        public CategoryController(IApiHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string url = _configuration["BaseURL"] + UrlStrings.GetAllCategory;
            var list = _apiHandler.GetApi<CustomResponseDto<List<CategoryDto>>>(url);
            return View(list.Data);
        }
        public JsonResult AddCategory(AddCategoryDto addCategory)
        {
            string url = _configuration["BaseURL"] + UrlStrings.AddCategory;
            var post = _apiHandler.PostApiString(addCategory, url);
            return Json(new { success = true });
        }
    }
}
