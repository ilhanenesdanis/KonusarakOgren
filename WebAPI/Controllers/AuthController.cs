using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public AuthController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult RegisterMember(RegisterDto register)
        {
           var result= _memberService.Register(register);
            if (result > 0)
            {
                return CreateActionResult(CustomResponseDto<MemberDto>.Success(200));
            }
            return CreateActionResult(CustomResponseDto<MemberDto>.Fail(404,"Kayıt Başarısız"));
        }
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _memberService.Login(loginDto);
            if (result == null)
            {
                return CreateActionResult(CustomResponseDto<MemberDto>.Fail(404, "Kullanıcı Bulunamadı"));
            }
            return CreateActionResult(CustomResponseDto<MemberDto>.Success(200,result));
        }
        [HttpGet]
        public IActionResult GetByCompany()
        {
            var result = _memberService.GetBy(x => x.RoleId == 2).ToList();
            var mapping = _mapper.Map<List<MemberDto>>(result);
            return CreateActionResult(CustomResponseDto<List<MemberDto>>.Success(200, mapping));
        }
    }
}
