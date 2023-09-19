using AndroidShoppingList.DataObjects;

namespace AndroidShoppingList.ScreenDisplays;

public partial class ListItemDisplay : ContentView
{
	public List<string> MeasurementUnitNames { get { return Enum.GetNames(typeof(MeasurementUnit)).ToList(); } }

    public ShoppingEntry CurrentEntry { get; set; }
    public ListItemDisplay()
	{
		InitializeComponent();
	}
}