using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Product
    {
        public static string Message;
    
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }


        public decimal CalculateTotal()
        {
            return this.CalculateTotal(0.08m);
        }


        public decimal CalculateTotal(decimal taxRate)
        {
            return this.CalculateTotal(taxRate, 0m);
        }

     


        public decimal CalculateTotal(decimal taxRate, decimal discount)
        {
            return this.Price + (this.Price * 0.08m) - discount;
        }


    }
}
