namespace Core.Entity
{
    public class Comment : BaseEntity
    {
        public string Messages { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
