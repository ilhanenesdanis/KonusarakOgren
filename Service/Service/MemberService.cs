using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;
using Service.Security;
using System.Security.Claims;

namespace Service.Service
{
    public class MemberService : Service<Member>, IMemberService
    {
        private readonly IRepository<Member> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private JwtSettings JwtSettings;
        public MemberService(IUnitOfWork unitOfWork, IRepository<Member> repository, IMapper mapper, IOptions<JwtSettings> jwtSettings) : base(unitOfWork, repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            JwtSettings = jwtSettings.Value;
        }

        public MemberDto Login(LoginDto loginDto)
        {
            var user = _repository.GetBy(x => x.Email == loginDto.Email).Include(x => x.Role).FirstOrDefault();

            if (user == null)
                return null;

            if (!HashHelper.VerigyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            

            var member = _mapper.Map<MemberDto>(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, member.Email));
            claims.Add(new Claim(ClaimTypes.Name, member.Name+" "+member.Surname));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            var token = JwtHelper.GetJwtToken(member.Name + " " + member.Surname, JwtSettings, new TimeSpan(0, 60, 0), claims.ToArray());
            member.Token = token;
            return member;


        }

        public int Register(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            if (registerDto.RoleId == 2)
            {
                Random random = new Random();
                string password = random.Next(0, 1000000).ToString();
                registerDto.Password = password;
            }
            HashHelper.CreatePasswordHash(registerDto.Password, out passwordHash, out passwordSalt);
            Member member = new Member()
            {
                CompanyName = registerDto.CompanyName,
                Email = registerDto.Email,
                Name = registerDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = registerDto.RoleId,
                Surname = registerDto.Surname,

            };
            _repository.Add(member);
            var Save = _unitOfWork.saveChanges();
            return Save;
        }
    }
}
