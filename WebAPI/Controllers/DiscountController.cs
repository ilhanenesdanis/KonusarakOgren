using AutoMapper;
using Core.Entity;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddDiscoutnt(AddDiscountDto addDiscount)
        {
            var mapping = _mapper.Map<Discount>(addDiscount);
            _discountService.Add(mapping);
            return CreateActionResult(CustomResponseDto<DiscountDto>.Success(200));
        }
        [HttpGet("{productFeatureId}")]
        public IActionResult GetFeatureDiscount(int productFeatureId)
        {
            var getDiscount = _discountService.GetBy(x => x.ProductFeatureId == productFeatureId).ToList();
            var mapper = _mapper.Map<List<DiscountDto>>(getDiscount);
            return CreateActionResult(CustomResponseDto<List<DiscountDto>>.Success(200, mapper));
        }
    }
}
