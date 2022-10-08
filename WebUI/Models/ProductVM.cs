using DTO;

namespace WebUI.Models
{
    public class ProductVM
    {
        public List<ProductDto> ProductDtos { get; set; }
        public List<BrandDto> BrandDtos { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
    }
}
