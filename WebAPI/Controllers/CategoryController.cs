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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var result = _mapper.Map<List<CategoryDto>>(_categoryService.GetBy(x => x.Status == true).ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, result));
        }
        [HttpPost]
        public IActionResult AddCategory(AddCategoryDto addCategory)
        {
            var result = _mapper.Map<Category>(addCategory);
            _categoryService.Add(result);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200));
        }
        [HttpPost]
        public IActionResult UpdateCategory(AddCategoryDto addCategory)
        {
            var result = _categoryService.GetById(addCategory.Id);
            result.TopCategoryId=addCategory.TopCategoryId!=0?addCategory.TopCategoryId:0;
            result.Name = addCategory.Name;
            _categoryService.Update(result);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200));
        }
    }
}
