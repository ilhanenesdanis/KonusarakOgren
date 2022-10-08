namespace DTO
{
    public class DiscountDto : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountRate { get; set; }
        public int ProductFeatureId { get; set; }
        public ProductFeaturesDto ProductFeatures { get; set; }
    }
}
