namespace Core.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int TopCategoryId { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
