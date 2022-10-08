namespace DTO
{
    public class AddProductFeatureDto
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}
