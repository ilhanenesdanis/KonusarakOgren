namespace DTO
{
    public class CommentDto : BaseDTO
    {
        public string Messages { get; set; }
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public MemberDto Member { get; set; }
        public ProductDto Product { get; set; }
    }
}
