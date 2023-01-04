// See https://aka.ms/new-console-template for more information

int account = 10000;
string pin = "1234";
bool isSignedIn = false;

// Keep the program running
while (true)
{
    if (!isSignedIn)
    {
        AuthorizeUser();
    }
    else
    {
        HandleSignedInSelections();
    }
}

// This method will prompt the user for the pin which will access the account.
void AuthorizeUser()
{
    Console.Clear();
    Console.WriteLine("Enter pin:");
    if (Console.ReadLine()! == pin)
    {
        isSignedIn = true;
        return;
    }

    Console.WriteLine("Pin is incorrect");
    PressAnyKey("Press any key to retry");
}

// This method will display and handle the selections once the user is signed in.
void HandleSignedInSelections()
{
    Console.Clear();
    Console.WriteLine("Select an option");
    Console.WriteLine("1 - Make a withdraw");
    Console.WriteLine("2 - Insert money");
    Console.WriteLine("3 - View account");
    Console.WriteLine("4 - Change pin");
    Console.WriteLine("5 - Sign out");
    switch (Console.ReadLine()!)
    {
        case "1":
            WithdrawMoney();
            break;
        case "2":
            InsertMoney();
            break;
        case "3":
            ViewAccount();
            break;
        case "4":
            ChangePin();
            break;
        case "5":
            isSignedIn = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            PressAnyKey("Press any key to retry");
            break;
    }
}

// This is a method for displaying a message and awaiting a click on any key in order to resume the program.
void PressAnyKey(string message = "Press any key to continue")
{
    Console.WriteLine(message);
    Console.ReadKey();
}

// This method will make a withdraw from the account.
void WithdrawMoney()
{
    Console.WriteLine("Enter amount to withdraw:");
    try
    {
        int amountToWithdraw = int.Parse(Console.ReadLine()!);
        if (amountToWithdraw > account)
        {
            Console.WriteLine("Invalid amount entered.");
            PressAnyKey();
            return;
        } 
        if (amountToWithdraw < 0)
        {
            Console.WriteLine("You can't withdraw a negative amount.");
            PressAnyKey();
            return;
        }

        account -= amountToWithdraw;
        Console.WriteLine("You have made a withdraw.");
        PressAnyKey();
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid input.");
        PressAnyKey();
    }
}

// This method will insert money to the account.
void InsertMoney()
{
    Console.WriteLine("Enter the amount you wish to deposit:");
    try
    {
        int amountToDeposit = int.Parse(Console.ReadLine()!);
        if (amountToDeposit < 0)
        {
            Console.WriteLine("You can't deposit a negative amount.");
            PressAnyKey();
            return;
        }

        account += amountToDeposit;
        Console.WriteLine("You have deposited money.");
        PressAnyKey();
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid input.");
        PressAnyKey();
    }
}

// This method will display the account.
void ViewAccount()
{
    Console.WriteLine($"Your account: {account}");
    PressAnyKey();
}

// This method will allow the user to change the pin.
void ChangePin()
{
    Console.WriteLine("Enter your new pin:");
    string newPin = Console.ReadLine()!;
    if (newPin.Any(char.IsLetter))
    {
        Console.WriteLine("A pin can only contain numbers.");
        PressAnyKey();
        return;
    }

    if (newPin.Length != 4)
    {
        Console.WriteLine("A pin should only be 4 digits.");
        PressAnyKey();
        return;
    }

    pin = newPin;
    Console.WriteLine("Your pin has been changed.");
    PressAnyKey();
}