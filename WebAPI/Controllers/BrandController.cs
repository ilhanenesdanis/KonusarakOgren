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
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllBrand()
        {
            var result = _mapper.Map<List<BrandDto>>(_brandService.GetBy(x => x.Status == true).ToList());
            return CreateActionResult(CustomResponseDto<List<BrandDto>>.Success(200, result));
        }
        [HttpPost]
        public IActionResult AddNewBrand(AddBrandDto brand)
        {
            var result = _mapper.Map<Brand>(brand);
            _brandService.Add(result);
            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200));
        }
        [HttpPost]
        public IActionResult UpdateBrand(AddBrandDto brandDto)
        {
            var result = _brandService.GetById(brandDto.Id);
            result.Name = brandDto.Name;
            _brandService.Update(result);
            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200));
        }
    }
}
