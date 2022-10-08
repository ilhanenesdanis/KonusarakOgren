namespace Core.Entity
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Product> Product { get; set; }
    }
}
