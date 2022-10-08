namespace DTO
{
    public class MemberDto:BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
        public List<CommentDto> Comments { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
