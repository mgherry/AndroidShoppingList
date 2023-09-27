using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AndroidShoppingList.ScreenDisplays
{
    public class ShoppingList : BindableObject
    {
        private static readonly int MAX_NUMBER_OF_ENTRIES = 5;

        private String _shoppingListName;
        public String ShoppingListName { get { return _shoppingListName; } set { _shoppingListName = value; OnPropertyChanged(nameof(ShoppingListName)); } }
        public bool IsNotFull { get { return EntriesList.Count < MAX_NUMBER_OF_ENTRIES; } }
        public bool IsEmpty { get { return EntriesList.Count == 0; } }

        private ObservableCollection<ShoppingItem> _entriesList;
        public ObservableCollection<ShoppingItem> EntriesList
        {
            get
            {
                _entriesList ??= new ObservableCollection<ShoppingItem>();
                return _entriesList;
            }
            set 
            { 
                _entriesList = value; 
                OnPropertyChanged(nameof(EntriesList)); 
            }
        }

        public ShoppingList() { ShoppingListName = "New Shopping List"; }

        public bool AddNewElement(ShoppingItem newEntry)
        {
            if (EntriesList.Count < MAX_NUMBER_OF_ENTRIES)
            {
                EntriesList.Add(newEntry);
                if (!IsNotFull) { OnPropertyChanged(nameof(IsNotFull)); }
                return true;
            }
            return false;
        }
    }
}
