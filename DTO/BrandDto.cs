namespace DTO
{
    public class BrandDto : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<ProductDto> Product { get; set; }
    }
}
