namespace UBB_SE_2024_Evil.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public float BidSum { get; set; }
        public DateTime TimeOfBid { get; set; }
        public User User { get; set; }
        public Auction Auction { get; set; }
    }
}
