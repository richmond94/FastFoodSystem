using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSystem
{
    public class Menu
    {
        private static int counter = 0;
        public int foodID;
        public string foodName;
        public string foodCategory;
        public string description;
        public double price;
        public int numberSold;

        public Menu()
        {
            generateFoodID();
            getFoodName();
            getFoodCategory();
            getDescription();
            getPrice();
        }

        public Menu(int foodID, string foodName, string foodCategory, string description, double price)
        {
            this.foodID = foodID;
            this.foodName = foodName;
            this.foodCategory = foodCategory;
            this.description = description;
            this.price = price;
        }

        private void generateFoodID()
        {
            foodID = System.Threading.Interlocked.Increment(ref counter);
        }

        private void getFoodName()
        {
            Console.WriteLine("Food Name:");
            foodName = Console.ReadLine();
        }

        private void getFoodCategory()
        {
            while (true)
            {
                Console.WriteLine("Please Select a Food Category:");
                Console.WriteLine("1. Starter");
                Console.WriteLine("2. Main Course");
                Console.WriteLine("3. Dessert");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            foodCategory = "Starter";
                            break;
                        case 2:
                            foodCategory = "Main Course";
                            break;
                        case 3:
                            foodCategory = "Dessert";
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void getDescription()
        {
            Console.WriteLine("Food Description:");
            description = Console.ReadLine();
        }

        private void getPrice()
        {
            Console.WriteLine("Enter Price:");
            if (double.TryParse(Console.ReadLine(), out double enteredPrice))
            {
                price = Math.Round(enteredPrice, 2);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid price.");
            }
        }

        public void displayMenu()
        {
            Console.WriteLine($"Food ID: {foodID}\nFood Name: {foodName}\nCategory: {foodCategory}\nDescription: {description}\nPrice: {price}\nNumber Sold: {numberSold}\n");
        }
    }
}
