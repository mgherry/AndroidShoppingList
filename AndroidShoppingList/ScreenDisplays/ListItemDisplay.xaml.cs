//using AndroidShoppingList.DataObjects;
using System.Linq;

namespace AndroidShoppingList.ScreenDisplays;

// TODO Delete class if not needed

public partial class ListItemDisplay : ContentView
{
    public List<string> MeasurementUnitNames { get { return Enum.GetNames(typeof(MeasurementUnit)).ToList(); } }

    private ShoppingItem _currentEntry;
    public ShoppingItem CurrentEntry
    {
        get
        {
            _currentEntry ??= new ShoppingItem();
            return _currentEntry;
        }
        set { _currentEntry = value; }
    }
    public ListItemDisplay()
	{
		InitializeComponent();
    }
}