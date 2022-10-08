namespace DTO
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }=String.Empty;
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    }
}
