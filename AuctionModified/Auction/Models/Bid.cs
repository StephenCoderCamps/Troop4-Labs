using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class Bid
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Bidder name is required!")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage="Invalid bid amount!")]
        public decimal BidAmount { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

    }
}