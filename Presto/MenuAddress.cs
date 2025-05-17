namespace Presto;

public class MenuAddress
{
    // private field to store the order choices, allowing for adding more items to current order
    private OrderInputAndOptions _orderChoice;

    // private field allow for edits to the current order
    private EditOrderItem _editOrderItem;

    // constructor to initialize the order choice and edit order item
    public MenuAddress(OrderInputAndOptions orderchoice, EditOrderItem editOrderItem)
    {
        _orderChoice = orderchoice;
        _editOrderItem = editOrderItem;
    }

    // prompts user to add more entrees to their order
    public void AddMoreEntrees()
    {
        while (_orderChoice.GetYesOrNo("Would you like to add another item to your order?"))
        {
            _orderChoice.StartNewEntree();

            _orderChoice.ChooseEntreeType();
            if (!_orderChoice.CurrentEntree.Any(option => option.Name == "BOWL"))
            {
                _orderChoice.ChooseBread();
            }
            _orderChoice.ChooseProtein();
            _orderChoice.ChooseRice();
            _orderChoice.ChooseSide();
            _orderChoice.ChooseAddOns();

            _editOrderItem.ShowOrderOptionsToEdit();

            _orderChoice.FinalizeEntree();

        }
    }
}
