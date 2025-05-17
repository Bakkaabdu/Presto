namespace Presto;

public class EditOrderItem
{
    // Stores the order data, allowing editing of current selections
    private OrderInputAndOptions _orderChoice;

    public EditOrderItem(OrderInputAndOptions orderchoice)
    {
        _orderChoice = orderchoice;
    }

    // Prompts the user to edit their order and guides them through the changes
    public void ShowOrderOptionsToEdit()
    {
        if (!_orderChoice.GetYesOrNo("Would you like to edit your order?"))
        {
            Console.WriteLine("No changes made to the order.");
            return;
        }


        Action[] editSteps =
        {
           _orderChoice.ChooseEntreeType,
           _orderChoice.ChooseBread,
           _orderChoice.ChooseProtein,
           _orderChoice.ChooseRice,
           _orderChoice.ChooseSide,
           _orderChoice.ChooseAddOns
        };

        Menu[] editOptions =
        {
            new Menu() { Name = "Edit Entree Type" },
            new Menu() { Name = "Edit Bread Type" },
            new Menu() { Name = "Edit Protein Type" },
            new Menu() { Name = "Edit Rice Option" },
            new Menu() { Name = "Edit Side Option" },
            new Menu() { Name = "Edit Extra Options" },
        };

        _orderChoice.ShowMenuOptions("SELECT WHAT YOU WANT TO EDIT:", editOptions);

        while (true)
        {
            int choice = _orderChoice.GetNumberInput("Enter the number of the item you'd like to edit: ", 1, editSteps.Length) - 1;

            switch (choice)
            {
                case 0:
                    _orderChoice.ClearEntreeType();
                    _orderChoice.ClearBread();
                    break;

                case 1:
                    _orderChoice.ClearBread();
                    break;

                case 2:
                    _orderChoice.ClearProtein();
                    break;

                case 3:
                    _orderChoice.ClearRice();
                    break;

                case 4:
                    _orderChoice.ClearSide();
                    break;

                case 5:
                    _orderChoice.ClearAddOns();
                    break;
            }

            editSteps[choice]();

            if (!_orderChoice.GetYesOrNo("Would you like to make another edit?"))
            {
                break;
            }
        }
    }
}
