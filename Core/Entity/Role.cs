namespace Core.Entity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Member> Member { get; set; }
    }
}
