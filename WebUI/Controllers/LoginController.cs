using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.APIHandler;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiHandler _apiHandler;
        public LoginController(IConfiguration configuration, IApiHandler apiHandler)
        {
            _configuration = configuration;
            _apiHandler = apiHandler;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(LoginDto login)
        {
            string url = _configuration["BaseURL"] + UrlStrings.LoginUser;
            var post = _apiHandler.PostApiString(login, url);
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterDto register)
        {
            string url = _configuration["BaseURL"] + UrlStrings.RegisterMember;
            var post = _apiHandler.PostApiString(register, url);
            return RedirectToAction("Index","Login");
        }
    }
}
