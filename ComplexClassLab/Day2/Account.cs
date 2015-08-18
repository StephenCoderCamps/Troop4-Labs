using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public bool IsOpen { get; set; }


        public Account(int id, string type, decimal amount, bool isOpen)
        {
            this.Id = id;
            this.Type = type;
            this.Amount = amount;
            this.IsOpen = isOpen;
        }

            
    }

}
