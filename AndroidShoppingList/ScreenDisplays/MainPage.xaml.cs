using AndroidShoppingList.ScreenDisplays;

namespace AndroidShoppingList;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnLastListClicked(object sender, EventArgs e)
	{
        // TODO
    }
    private void OnOpenListClicked(object sender, EventArgs e)
    {
        // TODO
    }
    private async void OnNewListClicked(object sender, EventArgs e) { await Shell.Current.GoToAsync(nameof(ListDisplayPage)); }
}

