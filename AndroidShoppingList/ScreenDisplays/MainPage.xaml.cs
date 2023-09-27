using AndroidShoppingList.ScreenDisplays;
using AndroidShoppingList.FileHandlerLogic;

namespace AndroidShoppingList;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnLatestListClicked(object sender, EventArgs e)
	{
        ShoppingList shoppingList = FileHandler.Instance.ReadLatestShoppingListFile();
        Dictionary<string, object> shoppingListData = new Dictionary<string, object>
        {
            { "CurrentList", shoppingList }
        };

        await Shell.Current.GoToAsync(nameof(ListDisplayPage), shoppingListData);
    }
    private async void OnOpenListClicked(object sender, EventArgs e)
    {
        // TODO
    }
    private async void OnNewListClicked(object sender, EventArgs e) { await Shell.Current.GoToAsync(nameof(ListDisplayPage)); }
}

