namespace Presto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // calls class and methods for greeting user and collecting name for order
            User customerName = new User();
            customerName.GreetAndCollectName();

            // create an instance of OrderInputAndOptions and CustomerReceipt
            OrderInputAndOptions orderInputAndOptions = new OrderInputAndOptions();
            CustomerReceipt customerReceipt = new CustomerReceipt(orderInputAndOptions);

            // set the CustomerReceipt instance in OrderInputAndOptions
            orderInputAndOptions.SetCustomerReceipt(customerReceipt);

            // calls class and methods for creating customers order
            orderInputAndOptions.ChooseEntreeType();

            // if bowl is not selected, prompt user to choose a tortilla
            if (!orderInputAndOptions.CurrentEntree.Any(option => option.Name == "Shawarma"))
            {
                orderInputAndOptions.ChooseBread();
            }

            orderInputAndOptions.ChooseProtein();
            orderInputAndOptions.ChooseRice();
            orderInputAndOptions.ChooseSide();
            orderInputAndOptions.ChooseAddOns();

            // prompt user to edit their order if needed and skips tortilla option if bowl is selected
            EditOrderItem orderEditor = new EditOrderItem(orderInputAndOptions);
            orderEditor.ShowOrderOptionsToEdit();

            if (!orderInputAndOptions.CurrentEntree.Any(option => option.Name == "Shawarma") && !orderInputAndOptions.CurrentEntree.Any(option => option.Name.Contains("Chicken")))
            {
                Console.WriteLine("Please select the bread you would like for your shawarma.");
                orderInputAndOptions.ChooseBread();
            }
            orderInputAndOptions.FinalizeEntree();

            // add more entrees if the user wants to
            MenuAddress menuOptionAdder = new MenuAddress(orderInputAndOptions, orderEditor);
            menuOptionAdder.AddMoreEntrees();

            // displays user receipt
            customerReceipt.DisplayReceipt(customerName);
        }
    }
}
