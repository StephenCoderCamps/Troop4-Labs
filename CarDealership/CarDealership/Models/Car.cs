using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class Car
    {   
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required] [MaxLength(500)]
        public string BriefDescription { get; set; }

        [Required]
        public string FullDescription { get; set; }

        public int Range { get; set; }

        public int ChargeTime { get; set; }


    }
}