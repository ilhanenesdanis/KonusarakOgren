namespace DTO
{
    public class AddProductDto
    {
        public AddProductDto()
        {
            CategoryId = new List<int>();
        }
        public string Name { get; set; } = string.Empty;//
        public string BarcodeNo { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }//
        public int Stock { get; set; }
        public int BrandId { get; set; }//
        public int CompanyId { get; set; }
        //ProductCategory
        public List<int> CategoryId { get; set; }//
        //ProductFeatures
        public string Color { get; set; }
        public string Size { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string ProductDescription { get; set; } = string.Empty;

    }
}
