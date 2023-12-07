using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSystem
{
    public class Order
    {
        private static int _counter = 0;

        public int OrderID;
        public Customer Customer;
        public List<Menu> Items;
        public DeliveryDriver AssignedDriver;
        public string SpecialRequests;
        public double TotalPrice;
        public OrderStatus Status;

        public enum OrderStatus
        {
            Received,
            Prepared,
            Cooking,
            Delivered
        }

        public Order(Customer customer)
        {
            OrderID = System.Threading.Interlocked.Increment(ref _counter);
            Customer = customer;
            Items = new List<Menu>();
            SpecialRequests = string.Empty;
            TotalPrice = 0;
            Status = OrderStatus.Received;
        }

        public void AddItem(Menu menuItem)
        {
            Items.Add(menuItem);
            TotalPrice += menuItem.price;
        }

        public void AssignDriver(DeliveryDriver driver)
        {
            AssignedDriver = driver;
        }

        public void AddSpecialRequests(string requests)
        {
            SpecialRequests = requests;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}");
            Console.WriteLine($"Customer: {Customer.GetCustomerName()}");
            Console.WriteLine("Items in the order:");
            foreach (var item in Items)
            {
                Console.WriteLine($"  - {item.foodName} (£{item.price})");
            }
            Console.WriteLine($"Special Requests: {SpecialRequests}");
            Console.WriteLine($"Total Price: £{TotalPrice}");

            if (AssignedDriver != null)
            {
                Console.WriteLine($"Assigned Driver: {AssignedDriver.GetDriverName()}");
            }
            else
            {
                Console.WriteLine("No driver assigned yet.");
            }

            Console.WriteLine($"Order Status: {Status}");
        }

        public static Order CreateOrderFromUserInput(List<Menu> menuList, List<Customer> customerList)
        {
            Console.WriteLine("Select a customer for the order:");
            Customer selectedCustomer = GetCustomerInformation(customerList);

            Order order = new Order(selectedCustomer);

            while (true)
            {
                Console.WriteLine("Add items to the order (enter menu item numbers, type 'done' to finish):");
                DisplayMenu(menuList);
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    break;
                }

                if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= menuList.Count)
                {
                    order.AddItem(menuList[itemNumber - 1]);
                    Console.WriteLine($"{menuList[itemNumber - 1].foodName} added to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid item number or type 'done' to finish.");
                }
            }

            Console.Write("Enter any special requests: ");
            string specialRequests = Console.ReadLine();
            order.AddSpecialRequests(specialRequests);

            return order;
        }


        private static Customer GetCustomerInformation(List<Customer> customerList)
        {
            Console.WriteLine("Select a customer:");

            DisplayCustomerList(customerList);

            while (true)
            {
                Console.Write("Enter the Customer ID: ");
                if (int.TryParse(Console.ReadLine(), out int selectedCustomerId))
                {
                    Customer selectedCustomer = customerList.FirstOrDefault(c => c.CustomerID == selectedCustomerId);

                    if (selectedCustomer != null)
                    {
                        Console.WriteLine($"Selected customer: {selectedCustomer.GetCustomerName()}");
                        return selectedCustomer;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Customer ID. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Customer ID.");
                }
            }
        }

        private static void DisplayCustomerList(List<Customer> customerList)
        {
            foreach (var customer in customerList)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerID}, Name: {customer.GetCustomerName()}");
            }
        }

        private static void DisplayMenu(List<Menu> menuList)
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menuList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuList[i].foodName} - £{menuList[i].price}");
            }
        }

        
        }
    }

