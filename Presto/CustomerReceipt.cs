namespace Presto;

public class CustomerReceipt
{
    // calling field from another class to get items selected by user
    private OrderInputAndOptions _orderChoice;

    // private field to generate a random number to attach to order
    private Random _rnd = new Random();

    // constructor to initialize the orderChoice instance
    public CustomerReceipt(OrderInputAndOptions orderchoice)
    {
        _orderChoice = orderchoice;
    }

    // generate order number
    public int GenerateOrderID()
    {
        return _rnd.Next(1, 100);
    }

    // gets complete order selected by user and displays it in a readable itemized format for user
    public string GetOrderDescription()
    {
        string orderDescription = "";
        int itemCount = 1;

        foreach (var entreeChoices in _orderChoice.AllEntrees)
        {
            orderDescription += GetEntreeDescription(entreeChoices, itemCount++);
        }

        if (_orderChoice.CurrentEntree.Any())
        {
            orderDescription += GetEntreeDescription(_orderChoice.CurrentEntree, itemCount);
        }
        return orderDescription;
    }

    //creates a readable description for a list of entrée choices
    public string GetEntreeDescription(List<Menu> entreeChoices, int itemCount)
    {
        string description = $"\n--- Entree {itemCount} ---";
        foreach (Menu item in entreeChoices)
        {
            description += $"\n{item.Name.ToUpper()}";
            if (item.Price != 0.00m)
            {
                description += "...." + item.Price.ToString("c");
            }
        }
        return description;
    }

    // adds together total tax and price of selected items to show user their total price
    public decimal CalculateSubTotal()
    {
        decimal subTotal = 0.00m;

        // calculate total for all completed entrées
        foreach (var entreeChoices in _orderChoice.AllEntrees)
        {
            subTotal += entreeChoices.Sum(item => item.Price);
        }

        // add total for the current entrée being built
        subTotal += _orderChoice.CurrentEntree.Sum(item => item.Price);

        return Math.Round(subTotal, 2);
    }

    // calculates total tax paid on total price of items selected by user
    public decimal CalculateTax(decimal subTotal)
    {
        decimal taxRate = 0.0815m;
        return Math.Round(subTotal * taxRate, 2);
    }

    // calculate final total price for customer based on selected items and tax rate
    public decimal CalculateTotal(decimal subTotal, decimal tax)
    {
        return subTotal + tax;
    }

    // displays full receipt to user
    public void DisplayReceipt(User ordername)
    {
        int orderId = GenerateOrderID();
        string orderDescription = GetOrderDescription();
        decimal subTotal = CalculateSubTotal();
        decimal tax = CalculateTax(subTotal);
        decimal total = CalculateTotal(subTotal, tax);

        Console.WriteLine($"\nThanks {ordername.Name}, your order is complete.");
        Console.WriteLine($"\nOrder ID: {orderId}");
        Console.WriteLine(orderDescription);
        Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
        Console.WriteLine($"TAX: ${tax}");
        Console.WriteLine($"TOTAL: ${total}");
    }
}
