using AndroidShoppingList.ScreenDisplays;

namespace AndroidShoppingList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ListDisplayPage), typeof(ListDisplayPage));
	}
}
