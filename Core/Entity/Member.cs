namespace Core.Entity
{
    public class Member : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
