using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BidAmount { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

    }
}