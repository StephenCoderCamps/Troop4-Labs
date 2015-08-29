using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinimumBid { get; set; }
        public int NumOfBids { get; set; }
        public ICollection<Bid> Bids { get; set; }

    }
}



/*You should be able to post a new item to auction. An auction item should have an Id, Name, Description, MinimumBid, and NumberOfBids property.
You should be able to enter a bid on existing auction item by entering your Name and BidAmount.
An auction closes automatically after NumberOfBids is reached.*/