namespace DTO
{
    public class CategoryDto : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public int TopCategoryId { get; set; }
        public List<ProductCategoryDto> ProductCategories { get; set; }
    }
}
