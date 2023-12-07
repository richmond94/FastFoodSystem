using FastFoodSystem;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Security.Cryptography;


int choice;


string connectionString = "Server=localhost;Database=fastfood;User Id=root;Password=root;";
// List<Customer> customerList = new List<Customer>();
List<DeliveryDriver> driverList = new List<DeliveryDriver>();
 List<Menu> menuList = new List<Menu>();
 List<Order> orderList = new List<Order>();



while (true)
{
    List<Customer> customerList = LoadCustomersFromDatabase();

    Console.WriteLine("Fast Food System\n");
    Console.WriteLine("1. Customer Menu\n");
    Console.WriteLine("2. Driver Menu\n");
    Console.WriteLine("3. Food Menu\n");
    Console.WriteLine("4. Order Menu\n");
    Console.WriteLine("5. Exit\n");
    Console.WriteLine("\nEnter Your Choice: ");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Customer Menu\n");
            Console.WriteLine("1. Display All Customers\n");
            Console.WriteLine("2. Add Customer\n");
            Console.WriteLine("3. Remove Customer\n");
            Console.WriteLine("4. Update Customer\n");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine("\nEnter Your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) 
            {
                
                foreach (Customer customer in customerList)
                {
                    customer.DisplayUser();
                }

            }
            else if (choice == 2)
            {
                Console.Clear();
                AddCustomerToDatabase(new Customer());
            }
            else if (choice == 3)
            {
                int deleteChoice;
                Console.WriteLine("Please Select a Customer to delete\n");
                

                foreach (Customer customer in customerList)
                {
                    customer.DisplayUser();
                }

                deleteChoice = Convert.ToInt32(Console.ReadLine());

                
                customerList.FindIndex(customer => customer.CustomerID == deleteChoice);

                if (deleteChoice != -1)
                {
                    
                    
                    DeleteCustomerFromDatabase(deleteChoice);
                    Console.WriteLine("Customer removed successfully.");
                }
                else
                {
                    Console.WriteLine("Customer with the specified ID not found.");
                }

            }
            else if (choice == 4)
            {


                Console.WriteLine("Please Select a Customer to edit\n");


                foreach (Customer customer in customerList)
                {
                    customer.DisplayUser();
                }
                int editChoice = Convert.ToInt32(Console.ReadLine());

                
                int IDToUpdate = customerList.FindIndex(customer => customer.CustomerID == editChoice);

                if (IDToUpdate != -1)
                {
                   
                    Customer customerToUpdate = customerList[IDToUpdate];

                    
                    Console.WriteLine("Enter updated information for the customer:");

                    Console.Write("Updated Name: ");
                    customerToUpdate.name = Console.ReadLine();

                    Console.Write("Updated Number: ");
                    customerToUpdate.contactNumber = Console.ReadLine();

                    Console.Write("Updated Address: ");
                    customerToUpdate.CustomerAddress = Console.ReadLine();

                    
                    UpdateCustomerInDatabase(customerToUpdate);
                    Console.WriteLine("Customer Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Customer with the specified ID not found.");
                }
            }
            else if (choice == 4) 
            {
                break;
            }



            else
            {
                Console.WriteLine("Invalid Option\n");
                break;
            }

            break;

        case 2:

            Console.Clear();
            Console.WriteLine("Driver Menu\n");
            Console.WriteLine("1. Display All Drivers\n");
            Console.WriteLine("2. Add Driver\n");
            Console.WriteLine("3. Remove Driver\n");
            Console.WriteLine("4. Update Driver\n");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine("\nEnter Your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {

                foreach (DeliveryDriver deliveryDriver in driverList)
                {
                    deliveryDriver.DisplayUser();
                }

            }
            else if (choice == 2)
            {
                Console.Clear();
                driverList.Add(new DeliveryDriver());

            }
            else if (choice == 3)
            {
                int deleteChoice;
                Console.WriteLine("Please Select a Driver to delete\n");
                Console.WriteLine("The first Driver displayed is 0 and increases by 1 for each entry\n");
                foreach (DeliveryDriver deliveryDriver in driverList)
                {
                    deliveryDriver.DisplayUser();
                }
                deleteChoice = Convert.ToInt32(Console.ReadLine());
                driverList.RemoveAt(deleteChoice);

            }
            else if (choice == 4)
            {
                int deleteChoice;
                Console.WriteLine("Please Select the ID of the Customer to edit\n");
                foreach (DeliveryDriver deliveryDriver in driverList)
                {
                    deliveryDriver.DisplayUser();
                }

                deleteChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Updated Name\n");
                driverList.Find(p => p.DriverID == deleteChoice).GetName();
                Console.WriteLine("Updated number\n");
                driverList.Find(p => p.DriverID == deleteChoice).GetContactNumber();
                Console.WriteLine("Updated Vehicle\n");
                driverList.Find(p => p.DriverID == deleteChoice).GetDriverVehicle();
            }
            else if (choice == 4)
            {
                break;
            }



            else
            {
                Console.WriteLine("Invalid Option\n");
                break;
            }


            break;

        case 3:

            Console.Clear();
            Console.WriteLine("Food Menu\n");
            Console.WriteLine("1. Display Menu\n");
            Console.WriteLine("2. Add Item To Menu\n");
            Console.WriteLine("3. Remove Item\n");
            Console.WriteLine("4. Update Item\n");
            Console.WriteLine("5. Menu Items Ranked\n");
            Console.WriteLine("6. Exit\n");
            Console.WriteLine("\nEnter Your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {

                foreach (Menu menu in menuList)
                {
                    menu.displayMenu();
                }

            }
            else if (choice == 2)
            {
                Console.Clear();
                menuList.Add(new Menu());

            }
            else if (choice == 3)
            {
                int deleteChoice;
                Console.WriteLine("Please Select a Item from the Menu to delete\n");
                Console.WriteLine("The first item displayed is 0 and increases by 1 for each entry\n");
                foreach (Menu menu in menuList)
                {
                    menu.displayMenu();
                }
                deleteChoice = Convert.ToInt32(Console.ReadLine());
                menuList.RemoveAt(deleteChoice);

            }
            else if (choice == 4)
            {
                int deleteChoice;
                Console.WriteLine("Please Select the ID of the Food Item to edit\n");
                foreach (Menu menu in menuList)
                {
                    menu.displayMenu();
                }
                deleteChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Updated Name\n");
                menuList.Find(p => p.foodID == deleteChoice).foodName = Console.ReadLine();
                Console.WriteLine("Updated number\n");
                menuList.Find(p => p.foodID == deleteChoice).foodCategory = Console.ReadLine();
                Console.WriteLine("Updated Vehicle\n");
                menuList.Find(p => p.foodID == deleteChoice).description = Console.ReadLine();
            }
            else if (choice == 5)
            {
                List<Menu> sortedMenuList = menuList.OrderByDescending(menu => menu.numberSold).ToList();
                Console.WriteLine("Menu Items ranked from most popular to least:");
                foreach (var menuItem in sortedMenuList)
                {
                    Console.WriteLine($"FoodID: {menuItem.foodID}, FoodName: {menuItem.foodName}, NumberSold: {menuItem.numberSold}");
                }
            }

            else if (choice == 6)
            {
                break;
            }


            else
            {
                Console.WriteLine("Invalid Option\n");
                break;
            }


            break;

        case 4:

            Console.Clear();
            Console.WriteLine("Order Menu\n");
            Console.WriteLine("1. Create Order\n");
            Console.WriteLine("2. Display Order\n");
            Console.WriteLine("3. Assign Driver\n");
            Console.WriteLine("4. Update order Status\n");
            Console.WriteLine("5. Display Total of Prices\n");
            Console.WriteLine("6. Exit\n");
            Console.WriteLine("\nEnter Your Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Creating Order...");
                Order order = Order.CreateOrderFromUserInput(menuList, customerList);
                orderList.Add(order);
                Console.WriteLine("Order Created Successfully!");
                Console.ReadKey();
                break;

            }
            else if (choice == 2)
            {
                Console.Clear();
                foreach (var order in orderList)
                {
                    Console.WriteLine("\nOrder details:");
                    order.DisplayOrderDetails();
                }

            }
            else if (choice == 3)
            {
                Console.Clear();
                foreach (var order in orderList)
                {
                    Console.WriteLine("\nOrder details:");
                    order.DisplayOrderDetails();
                }

                Console.WriteLine("Enter Order ID to assign a driver:");
                int orderId = Convert.ToInt32(Console.ReadLine());

                Order orderToAssign = orderList.FirstOrDefault(o => o.OrderID == orderId);

                if (orderToAssign != null)
                {
                    

                    Console.WriteLine("Select a driver:");

                    foreach (var driver in driverList)
                    {
                        Console.WriteLine($"Driver ID: {driver.DriverID}, Name: {driver.GetDriverName()}");
                    }

                    Console.Write("Enter the Driver ID: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedDriverId))
                    {
                        DeliveryDriver selectedDriver = driverList.FirstOrDefault(d => d.DriverID == selectedDriverId);

                        if (selectedDriver != null)
                        {
                            orderToAssign.AssignDriver(selectedDriver);
                            string driverName = selectedDriver.GetDriverName();
                            Console.WriteLine($"Driver {driverName} assigned to the order!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Driver ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Driver ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }

            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter Order ID to update status:");
                int orderId = Convert.ToInt32(Console.ReadLine());

                Order orderToUpdate = orderList.FirstOrDefault(o => o.OrderID == orderId);

                if (orderToUpdate != null)
                {
                    Console.WriteLine($"Current Status: {orderToUpdate.Status}");
                    Console.WriteLine("Enter new status (Received, Prepared, Cooking, Delivered):");
                    string newStatus = Console.ReadLine();

                    if (Enum.TryParse(newStatus, true, out Order.OrderStatus status))
                    {
                        orderToUpdate.UpdateStatus(status);
                        Console.WriteLine("Status Updated Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid status input.");
                    }
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            else if (choice == 5)
            {
                double total = 0;
                foreach (var order in orderList)
                {
                    total += order.TotalPrice;
                }

                Console.WriteLine($"Total of Orders: £{total}");
            }

            else if (choice == 6)
            {
                break;
            }



            else
            {
                Console.WriteLine("Invalid Option\n");
                break;
            }


            

            break;

        case 5:

            
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid Option");
            break;


        
    }




}

 


  List<Customer> LoadCustomersFromDatabase()
{
    List<Customer> customerList = new List<Customer>();

    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "SELECT * FROM customers";

        using (var command = new MySqlCommand(query, connection))
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int customerId = reader.GetInt32("CustomerID");
                string name = reader.GetString("Name");
                string contactNumber = reader.GetString("ContactNumber");
                string customerAddress = reader.GetString("CustomerAddress");

                Customer customer = new Customer(customerId, name, contactNumber, customerAddress);
                customerList.Add(customer);
            }
        }
    }

    return customerList;
}


 void AddCustomerToDatabase(Customer customer)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "INSERT INTO Customers (Name, ContactNumber, CustomerAddress) VALUES (@Name, @ContactNumber, @CustomerAddress)";

        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", customer.name);
            command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
            command.Parameters.AddWithValue("@ContactNumber", customer.contactNumber);
            command.ExecuteNonQuery();
        }
    }
}

 void UpdateCustomerInDatabase(Customer customer)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "UPDATE Customers SET Name = @Name, ContactNumber = @ContactNumber, CustomerAddress = @CustomerAddress WHERE CustomerID = @CustomerID";

        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", customer.name);
            command.Parameters.AddWithValue("@ContactNumber", customer.contactNumber);
            command.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
            command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

            command.ExecuteNonQuery();
        }
    }
}

 void DeleteCustomerFromDatabase(int customerId)
{
    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@CustomerID", customerId);

            command.ExecuteNonQuery();
        }
    }
}
    