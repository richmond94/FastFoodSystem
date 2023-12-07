using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSystem
{
    public abstract class Person
    {
        public string name;
        public string contactNumber;
        public Person()
        {
            GetName();
            GetContactNumber();
        }

        public Person(string name, string contactNumber)
        {
            this.name = name;
            this.contactNumber = contactNumber;
        }

        public void GetName()
        {
            Console.WriteLine("Name:");
            name = Console.ReadLine();
        }

        public void GetContactNumber()
        {
            Console.WriteLine("Number:");
            contactNumber = Console.ReadLine();
        }

        public void DisplayUser()
        {
            Console.WriteLine("Name: " + this.name + "\n "
                    + "Number: " + this.contactNumber + "\n ");
        }
        
    }
}
