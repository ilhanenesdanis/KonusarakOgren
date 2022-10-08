namespace DTO
{
    public class RoleDto: BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<MemberDto> Member { get; set; }
    }
}
