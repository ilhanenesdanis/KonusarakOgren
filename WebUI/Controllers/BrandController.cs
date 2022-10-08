using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;

namespace WebUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;
        public BrandController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            string url = _configuration["BaseURL"] + UrlStrings.GetAllBrand;
            var result=_apiHandler.GetApi<CustomResponseDto<List<BrandDto>>>(url);
            return View(result.Data);
        }
    }
}
