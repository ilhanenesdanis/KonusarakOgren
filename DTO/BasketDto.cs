namespace DTO
{
    public class BasketDto:BaseDTO
    {
        public int MemberId { get; set; }
        public MemberDto Member { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
