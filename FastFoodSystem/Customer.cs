using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSystem
{

    public class Customer : Person
    {
        private static int counter = 0;
        public int CustomerID;
        public string CustomerAddress;

        public Customer()
        {
            GetCustomerID();
            GetCustomerAddress();
        }

        public Customer(int customerID, string name, string customerAddress, string contactNumber)
        {
            
            
            this.CustomerID = customerID;
            this.name = name;
            this.CustomerAddress = customerAddress;
            this.contactNumber = contactNumber;
        }

        private void GetCustomerID()
        {
            CustomerID = System.Threading.Interlocked.Increment(ref counter);
        }

        public void GetCustomerAddress()
        {
            Console.WriteLine("Address:");
            CustomerAddress = Console.ReadLine();
        }

        public void DisplayUser()
        {
            Console.WriteLine("ID: " + this.CustomerID + "\n "
                    + "Name: " + this.name + "\n "
                    + "Address: " + this.CustomerAddress + "\n "
                    + "Number: " + this.contactNumber + "\n ");
        }

        public string GetCustomerName()
        {
            return name;
        }
        public string GetAddress()
        {
            return name;
        }
        public string GetNumber()
        {
            return contactNumber;
        }
        public int GetID()
        {
            return CustomerID;
        }
    }
















}
