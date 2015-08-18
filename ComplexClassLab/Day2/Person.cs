using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Person
    {
        

        public Person(string firstName = "John", string lastName="Doe")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Person()
        {
            this.FirstName = "Jane";
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

    }
}
