using Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.Views.Bids
{
    public class BidVM
    {
        public IList<Bid> Bids { get; set; }
        public Bid Bid { get; set; }
    
    }
}