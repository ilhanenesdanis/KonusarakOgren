namespace DTO
{
    public class ProductDto:BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string BarcodeNo { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
    }
}
