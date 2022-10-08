using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.IUnitOfWork;
using DTO;
using Microsoft.EntityFrameworkCore;
using Service.IService;

namespace Service.Service
{
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IUnitOfWork unitOfWork, IRepository<Basket> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _basketRepository=repository;
        }

        public List<BasketDto> GetMemberBasket(int memberId)
        {
            var result = _basketRepository.GetBy(x => x.MemberId == memberId).Include(x => x.Product).ToList();
            var mapping = _mapper.Map<List<BasketDto>>(result);
            return mapping;
        }
    }
}
