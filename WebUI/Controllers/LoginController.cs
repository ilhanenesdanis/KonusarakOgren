using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            var post = _apiHandler.PostApi<CustomResponseDto<MemberDto>>(login, url);
           
            JwtSecurityTokenHandler tokenHandler = new();
            var token = tokenHandler.ReadJwtToken(post.Data.Token);
            if (token != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                string nameIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
                string RoleIdentifier = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
                var MemberName = token.Claims.Where(x => x.Type == nameIdentifier).Select(x => x.Value).FirstOrDefault();
                var roles = token.Claims.Where(x => x.Type == RoleIdentifier).Select(x => x.Value).FirstOrDefault();
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(2),
                    MaxAge = TimeSpan.FromDays(2),
                    HttpOnly = true
                };
                Response.Cookies.Append("security-token", post.Data.Token.ToString(), options);
                HttpContext.Response.Cookies.Append("MemberId", post.Data.Id.ToString(), options);
                HttpContext.Response.Cookies.Append("roles", roles, options);
            }
            return RedirectToAction("Index","Product");
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
            return RedirectToAction("Index", "Login");
        }
    }
}
