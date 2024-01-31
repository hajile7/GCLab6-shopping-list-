//welcome message
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

Console.WriteLine("Welcome to the berry market!\n");

//create our infinite program loop
bool runProgram = true;
while (runProgram)
{
    //create our catalogue of items
    Dictionary<string, decimal> Menu = new Dictionary<string, decimal>();
    Menu.Add("strawberries", (decimal)3.99);
    Menu.Add("blueberries", (decimal)3.50);
    Menu.Add("elderberries", (decimal)4.99);
    Menu.Add("acai berries", (decimal)6.99);
    Menu.Add("gooseberries", (decimal)5.99);
    Menu.Add("goji berries", (decimal)6.99);
    Menu.Add("cranberries", (decimal)4.25);
    Menu.Add("raspberries", (decimal)5.00);

    //create shopping list variable
    List<string> shoppingList = new List<string>();

    //begin the shopping loop
    bool isShopping = true;
    while (isShopping)
    {
        //create header for aesthetic purposes
        Console.WriteLine("Item\t\t\tPrice");
        Console.WriteLine("=============================");

        //display our catalogue of items to the user
        int i = 1; //this int is used to print the numbers beside our menu for the extendeds
        foreach (KeyValuePair<string, decimal> kvp in Menu)
        {
            Console.WriteLine(string.Format("{0}: {1}\t\t{2}", i, kvp.Key, kvp.Value.ToString("0.00"))); //use string format and ToString to clean up the menu
            i++;
        }
        //ask for item + store it
        Console.Write("What item would you like to purchase? Please enter its name or menu number: ");
        string itemChoice = Console.ReadLine().ToLower().Trim();

        //menu number logic
        if (itemChoice == "1")
        {
            itemChoice = "strawberries";
        }
        else if (itemChoice == "2")
        {
            itemChoice = "blueberries";
        }
        else if (itemChoice == "3")
        {
            itemChoice = "elderberries";
        }
        else if (itemChoice == "4")
        {
            itemChoice = "acai berries";
        }
        else if (itemChoice == "5")
        {
            itemChoice = "gooseberries";
        }
        else if (itemChoice == "6")
        {
            itemChoice = "goji berries";
        }
        else if (itemChoice == "7")
        {
            itemChoice = "cranberries";
        }
        else if (itemChoice == "8")
        {
            itemChoice = "raspberries";
        }

        //logic for whether or not the item is in the dictionary
        while (!Menu.ContainsKey(itemChoice)) //loop input until we get something valid
        {
            Console.Write("We do not carry that. Please try again: ");
            itemChoice = Console.ReadLine().ToLower().Trim();
        }
        if (Menu.ContainsKey(itemChoice)) //adds item to list + displays it was added and price to user
        {
            shoppingList.Add(itemChoice);
            Console.WriteLine($"Added {itemChoice} to the cart for ${Menu[itemChoice].ToString("0.00")}");
        }

        //see if user would like to purchase another item
        Console.WriteLine("Would you like to purchase another item? y/n");
        string contShopping = Console.ReadLine().ToLower().Trim();
        if (contShopping == "y")
        {
            continue;
        }
        else if (contShopping == "n")
        {
            isShopping = false;
        }


    }

    //receipt contents output
    Console.WriteLine("Thank you for the order! Here's your receipt:");
    foreach (string bought in shoppingList)
    {
        Console.WriteLine(bought + "\t$" + Menu[bought].ToString("0.00")); //ToString to force two decimals
    }

    //total output
    decimal total = 0;
    foreach (string bought in shoppingList)
    {
        total += Menu[bought];
    }
    Console.WriteLine($"Your total is ${total}");

    //find most expensive item
    var mostExpensiveItem = Menu.MaxBy(pair => pair.Value); //I used var here because its more readable than explicity naming the variable as a keyvaluepair
    Console.WriteLine($"The most expensive thing you purchased was {mostExpensiveItem.Key} for {mostExpensiveItem.Value.ToString("0.00")}.");

    //find least expensive item
    var leastExpensiveItem = Menu.MinBy(pair => pair.Value);
    Console.WriteLine($"The least expensive thing you purchased was {leastExpensiveItem.Key} for {leastExpensiveItem.Value.ToString("0.00")}.");

    //ask if user would like to continue using the program
    while (true)
    {
        Console.WriteLine("Would you like to start another order? y/n");
        string progChoice = Console.ReadLine().ToLower().Trim();
        if (progChoice == "n")
        {
            Console.WriteLine("Thank you for shopping with us today!");
            runProgram = false;
            break;
        }
        else if (progChoice == "y")
        {
            Console.Clear();
            break;
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}