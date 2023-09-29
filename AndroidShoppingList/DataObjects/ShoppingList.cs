using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AndroidShoppingList.ScreenDisplays
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ShoppingList : BindableObject
    {
        private static readonly int MAX_NUMBER_OF_ENTRIES = 50;
        private static readonly int MAX_LENGTH_OF_SHOPPING_LIST_NAME = 100;

        private String _shoppingListName;
        [JsonProperty]
        public String ShoppingListName { 
            get { return _shoppingListName; } 
            set { 
                _shoppingListName = TrunkateNameToMaxLength(value);
                OnPropertyChanged(nameof(ShoppingListName)); 
            } 
        }

        public bool IsNotFull { get { return EntriesList.Count < MAX_NUMBER_OF_ENTRIES; } }
        public bool IsEmpty { get { return EntriesList.Count == 0; } }

        private ObservableCollection<ShoppingItem> _entriesList;
        [JsonProperty]
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

        public bool DeleteElement(ShoppingItem deleteEntry)
        {
            if (EntriesList.Count > 0)
            {
                EntriesList.Remove(deleteEntry); OnPropertyChanged(nameof(IsNotFull));
                return true;
            }
            return false;
        }

        public static string TrunkateNameToMaxLength(string givenName)
        {
            if (string.IsNullOrEmpty(givenName)) return givenName;
            return givenName.Length <= MAX_LENGTH_OF_SHOPPING_LIST_NAME ? givenName : givenName.Substring(0, MAX_LENGTH_OF_SHOPPING_LIST_NAME);
        }
    }
}
