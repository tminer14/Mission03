

using System.Diagnostics;
using System.Runtime.InteropServices;
using Mission03;


//initialize the variables
string response = "";
int number = 0;
bool isFirst = true;
List<FoodItem> inventory = new List<FoodItem>();



while (true) // Infinite loop until a valid response is entered
{
    if (isFirst)
    {
        //welcome message with options
        Console.WriteLine("Welcome to the Food Bank Inventory System! Please choose an action: " +
            "\n1: Add food item." +
            "\n2: Delete food item." +
            "\n3: Print list of current food items." +
            "\n4: Exit.");
        isFirst = false; // After the first time, set isFirst to false
    }

    else //show options again 
    {
        Console.WriteLine("\nPlease select any other actions you would like to do. " +
    "\n1: Add food item." +
    "\n2: Delete food item." +
    "\n3: Print list of current food items." +
    "\n4: Exit.");
    }

    
    response = Console.ReadLine();

    if (int.TryParse(response, out number)) // Check if input is a number
    {
        if (number >= 1 && number <= 4) // Check if number is in the valid range
        {
           
            if (number == 1)
            {
                Console.WriteLine("\nPlease enter the name of the item you'd like to add: ");
                string name = Console.ReadLine();

                //data validation
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                    name = Console.ReadLine();
                }

                Console.WriteLine("\nPlease enter the category of the item you'd like to add: ");
                string category = Console.ReadLine();
                //data validation
                while (string.IsNullOrWhiteSpace(category))
                {
                    Console.WriteLine("Category cannot be empty. Please enter a valid category:");
                    category = Console.ReadLine();
                }

                Console.WriteLine("\nPlease enter the number of units in number form: ");
                int quantity;

                //data validation
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive number:");
                }

                Console.WriteLine("\nPlease enter the expiration date in this format: (MM/DD/YYYY) ");
                DateTime expDate;

                //data validation
                while (!DateTime.TryParse(Console.ReadLine(), out expDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date (MM/DD/YYYY):");
                }

                FoodItem fi = new FoodItem(name, category, quantity, expDate);
                inventory.Add(fi);
                Console.WriteLine($"\n{name} has been added.");
            }

            if (number == 2)
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("\nThe inventory is empty. There is nothing to delete.");
                    continue;
                }

                //list out the different items for the user to choose from 
                Console.WriteLine("\nType the number of the item you would like to delete: ");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"\nItem {i + 1}:");
                    Console.WriteLine($"Name: {inventory[i].name}");
                    Console.WriteLine($"Category: {inventory[i].category}");
                    Console.WriteLine($"Quantity: {inventory[i].quantity}");
                    Console.WriteLine($"Expiration Date: {inventory[i].expDate.ToShortDateString()}");
                }

                string deleteInput = Console.ReadLine();
                if (int.TryParse(deleteInput, out int choice) && choice >= 1 && choice <= inventory.Count)
                {
                    //adjust the number they put in so that it corresponds to the proper number in the list
                    Console.WriteLine($"\n{inventory[choice - 1].name} has been deleted.");
                    inventory.RemoveAt(choice - 1);
                }

                //data validation
                else
                {
                    Console.WriteLine("\nInvalid choice. Please select a valid item number.");
                }
            }



            if (number == 3)
            {
                //list out the items
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"\nItem {i + 1}:");
                    Console.WriteLine($"Name: {inventory[i].name}");
                    Console.WriteLine($"Category: {inventory[i].category}");
                    Console.WriteLine($"Quantity: {inventory[i].quantity}");
                    Console.WriteLine($"Expiration Date: {inventory[i].expDate.ToShortDateString()}");
                }
            }

            //exit program
            if (number == 4)
            {
                Console.WriteLine("Exiting program now...");
                break;
            }

        }
        else
        {
            Console.WriteLine("The response must be between 1 and 4. Please try again.");
        }
    }
    else
    {
        Console.WriteLine("That is not a valid response. Please try again.");
    }
}
    

