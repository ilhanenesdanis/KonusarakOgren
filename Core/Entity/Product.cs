namespace Core.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string BarcodeNo { get; set; } = string.Empty;
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int BrandId { get; set; }
        public int CompanyId { get; set; }
        public Brand Brand { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductFeatures> ProductFeatures { get; set; }
    }
}
