using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO;
using Service.IService;
using Service.Security;

namespace Service.Service
{
    public class MemberService : Service<Member>, IMemberService
    {
        private readonly IRepository<Member> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MemberService(IUnitOfWork unitOfWork, IRepository<Member> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public MemberDto Login(LoginDto loginDto)
        {
            var user = _repository.GetBy(x => x.Email == loginDto.Email).FirstOrDefault();

            if (user == null)
                return null;

            if (!HashHelper.VerigyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            var member = _mapper.Map<MemberDto>(user);
            return member;
            

        }

        public int Register(RegisterDto registerDto)
        {
            byte[] passwordHash, passwordSalt;
            if (registerDto.RoleId == 2)
            {
                Random random = new Random();
                string password=random.Next(0, 1000000).ToString();
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
