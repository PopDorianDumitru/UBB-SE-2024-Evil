using System.Security.Cryptography.Pkcs;

namespace UBB_SE_2024_Evil.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }
        public string AuctionDescription { get; set; }
        public string AuctionName { get; set; }
        public float CurrentMaxSum { get; set; }
        public DateTime DateOfStart { get; set; }
        public List<User> Users { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
