namespace Core.Entity
{
    public class Discount:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountRate { get; set; }
        public int ProductFeatureId { get; set; }
        public ProductFeatures ProductFeatures { get; set; }
    }
}
