using Core.Entity;
using Core.IService;
using DTO;

namespace Service.IService
{
    public interface IMemberService:IService<Member>
    {
        int Register(RegisterDto registerDto);
        MemberDto Login(LoginDto loginDto);
    }
}
