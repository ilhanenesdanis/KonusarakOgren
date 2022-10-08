namespace DTO
{
    public class ProductFeaturesDto:BaseDTO
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public List<DiscountDto> Discounts { get; set; }
    }
}
