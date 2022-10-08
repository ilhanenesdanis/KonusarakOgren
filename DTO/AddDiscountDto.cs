namespace DTO
{
    public class AddDiscountDto
    {
        public string Name { get; set; }=String.Empty;
        public string Description { get; set; } = String.Empty;
        public int DiscountRate { get; set; }
        public int ProductFeatureId { get; set; }
    }
}
