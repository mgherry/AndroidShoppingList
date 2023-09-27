//using AndroidShoppingList.DataObjects;

namespace AndroidShoppingList.ScreenDisplays;

public partial class ListDisplayPage : ContentPage
{
    public ShoppingList _currentList;
    public ShoppingList CurrentList
    {
        get
        {
            _currentList ??= new ShoppingList();
            return _currentList;
        }
        set { _currentList = value; }
    }

	public ListDisplayPage()
	{
		InitializeComponent();
        //
        CurrentList.AddNewElement(new ShoppingItem());
    }

    private void OnAddNewItemClicked(object sender, EventArgs e)
    {
        CurrentList.AddNewElement(new ShoppingItem());
    }
}