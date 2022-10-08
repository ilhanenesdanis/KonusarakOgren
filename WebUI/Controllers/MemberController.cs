using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;

namespace WebUI.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;

        public MemberController(IApiHandler apiHandler, IConfiguration configuration)
        {
            _apiHandler = apiHandler;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string url = _configuration["BaseURL"] + UrlStrings.GetByCompany;
            var list = _apiHandler.GetApi<CustomResponseDto<List<MemberDto>>>(url);
            return View(list.Data);
        }
        public JsonResult AddMember(RegisterDto registerDto)
        {
            registerDto.RoleId = 2;
            string url = _configuration["BaseURL"] + UrlStrings.RegisterMember;
            var post = _apiHandler.PostApiString(registerDto, url);
            return Json(new { success = true });
        }
    }
}
