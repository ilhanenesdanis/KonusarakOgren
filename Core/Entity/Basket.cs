namespace Core.Entity
{
    public class Basket : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
