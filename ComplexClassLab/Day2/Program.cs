using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var alice = new Customer(456, "Alice", "Willams");
            alice.Checking.Amount=100m;
            alice.Checking.IsOpen = true;

            alice.Savings.Amount = 0m;
            alice.Savings.IsOpen = false;
            alice.Transfer(AccountTypes.Checking, 50m);




        }
    }
}
