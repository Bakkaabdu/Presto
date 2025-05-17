using System.Text.RegularExpressions;

namespace Presto;

public class User
{
    private string _name;

    // property to get and set the name
    public string Name { get; private set; } = string.Empty;

    // greets the user and prompts them to enter a name for the order
    public void GreetAndCollectName()
    {
        Console.WriteLine("Hello, Welcome to Abdulrahman's Shawarma Corner.");

        Console.WriteLine("Please enter a name for this order: ");
        string input = Console.ReadLine();

        if (IsValidName(input))
        {
            Name = input;
            Console.WriteLine($"Welcome {Name}, please use the numbers provided when making a selection.");
        }
        else
        {
            Console.WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
        }

    }

    // validates the user's name to ensure it contains only alphabetical characters and spaces, and is between 1 and 26 characters long
    public bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,26}$");
    }
}
