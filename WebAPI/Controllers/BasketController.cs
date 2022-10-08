using AutoMapper;
using Core.Entity;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }
        [HttpGet("{memberId}")]
        public IActionResult GetMemberBasket(int memberId)
        {
            var result = _basketService.GetMemberBasket(memberId);
            return CreateActionResult(CustomResponseDto<List<BasketDto>>.Success(200,result));
        }
        [HttpPost]
        public IActionResult AddBasket(AddBasketDto addBasket)
        {
            var map = _mapper.Map<Basket>(addBasket);
            _basketService.Add(map);
            return CreateActionResult(CustomResponseDto<BasketDto>.Success(200));
        }
        [HttpGet("{MemberId}")]
        public IActionResult PurcheseAll(int MemberId)
        {
            var basketList = _basketService.GetBy(x => x.MemberId == MemberId).ToList();
            _basketService.DeleteRange(basketList);
            return CreateActionResult(CustomResponseDto<BasketDto>.Success(200));
        }
    }
}
