using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Customer
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public Account Savings { get; set; }

        public Account Checking { get; set; }

        public Customer(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Savings = new Account(this.Id, "Savings", 0m, false);
            this.Checking = new Account(this.Id, "Checking", 0m, false);
        }

        public void Transfer(AccountTypes fromType, decimal amount) {

            if (fromType == AccountTypes.Checking) 
            {
                if (this.Checking.Amount >= amount) 
                {    
                this.Checking.Amount -= amount;
                this.Savings.Amount += amount;
                this.Savings.IsOpen = true;
                
                }

            }

            else 
            {
                if (fromType == AccountTypes.Savings)
                {
                    if (this.Savings.Amount >= amount)
                    {
                        this.Savings.Amount -= amount;
                        this.Checking.Amount += amount;
                        this.Checking.IsOpen = true;
                
                     }

                }
                    
                 
            }

    
        }


    }
}
