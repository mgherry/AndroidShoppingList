using AndroidShoppingList.DataObjects;

namespace AndroidShoppingList.ScreenDisplays;

public partial class ListDisplayPage : ContentPage
{
	public ShoppingList CurrentList { get; set; }

	public ListDisplayPage()
	{
		InitializeComponent();
	}

    private void OnAddNewItemClicked(object sender, EventArgs e)
    {
        // TODO
        ListItemsArray.Add(new ListItemDisplay());
    }
}