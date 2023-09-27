//using AndroidShoppingList.DataObjects;
using AndroidShoppingList.FileHandlerLogic;

namespace AndroidShoppingList.ScreenDisplays;

[QueryProperty(nameof(CurrentList), "CurrentList")]
public partial class ListDisplayPage : ContentPage
{
    public ShoppingList _currentList;
    public ShoppingList CurrentList {
        get
        {
            _currentList ??= new ShoppingList();
            return _currentList;
        }
        set { _currentList = value; OnPropertyChanged(nameof(CurrentList)); }
    }

	public ListDisplayPage() {
		InitializeComponent();
        //
        if (CurrentList.IsEmpty) CurrentList.AddNewElement(new ShoppingItem());
    }

    private void OnAddNewItemClicked(object sender, EventArgs e) {
        CurrentList.AddNewElement(new ShoppingItem());
    }

    private void OnSaveListClicked(object sender, EventArgs e) {
        FileHandler.Instance.WriteShoppingListFile(CurrentList);
    }
}