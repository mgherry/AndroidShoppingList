//using AndroidShoppingList.DataObjects;
using AndroidShoppingList.FileHandlerLogic;
using System.Windows.Input;

namespace AndroidShoppingList.ScreenDisplays;

[QueryProperty(nameof(CurrentList), "CurrentList")]
public partial class ListDisplayPage : ContentPage
{
    public ICommand DeleteCommand { get; }

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
        DeleteCommand = new Command<ShoppingItem>(OnDeleteItemClicked);
        //
        if (CurrentList.IsEmpty) CurrentList.AddNewElement(new ShoppingItem());
    }

    private void AddNewShoppingItem() {
        bool elementAdded = CurrentList.AddNewElement(new ShoppingItem());
    }

    private void OnAddNewItemClicked(object sender, EventArgs e) {
        AddNewShoppingItem();
    }

    private void OnSaveListClicked(object sender, EventArgs e) {
        FileHandler.Instance.WriteShoppingListFile(CurrentList);
    }

    private void OnDeleteItemClicked(ShoppingItem shoppingItem) {
        CurrentList.DeleteElement(shoppingItem);
    }
}