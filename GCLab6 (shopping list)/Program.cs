//welcome message
Console.WriteLine("Welcome to the berry market!\n");

//create out infinite program loop
bool runProgram = true;
while (runProgram)
{
    //create our catalogue of items
    Dictionary<string, decimal> Menu = new Dictionary<string, decimal>();
    Menu.Add("strawberries", (decimal)3.99);
    Menu.Add("blueberries", (decimal)3.50);
    Menu.Add("elderberries", (decimal)4.99);
    Menu.Add("boysenberries", (decimal)6.99);
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
        Console.WriteLine("Item\t\tPrice");
        Console.WriteLine("=====================");

        //display our catalogue of items to the user
        foreach (KeyValuePair<string, decimal> kvp in Menu)
        {
            Console.WriteLine(kvp);
        }
        //ask for item + store it
        Console.Write("What item would you like to purchase? ");
        string itemChoice = Console.ReadLine().ToLower().Trim();

        //logic for whether or not the item is in the dictionary
        while (!Menu.ContainsKey(itemChoice)) //loop input until we get something valid
        {
            Console.Write("We do not carry that. Please try again: ");
            itemChoice = Console.ReadLine().ToLower().Trim();
        }
        if (Menu.ContainsKey(itemChoice)) //adds item to list + displays it was added and price to user
        {
            shoppingList.Add(itemChoice);
            Console.WriteLine($"Added {itemChoice} to the cart for ${Menu[itemChoice]}");
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

    //receipt output
    Console.WriteLine("Thank you for the order! Here's your receipt:");
    foreach (string bought in shoppingList)
    {
        Console.WriteLine(bought + "\t$" + Menu[bought]);
    }


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
