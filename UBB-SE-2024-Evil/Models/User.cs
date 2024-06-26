﻿namespace UBB_SE_2024_Evil.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public List<Bid> Bids { get; set; }
        public List<Auction> Auctions { get; set; }
    }
}
