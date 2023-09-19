using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShoppingList.DataObjects
{
    public class ShoppingList
    {
        private static readonly int MAX_NUMBER_OF_ENTRIES = 100;

        public String Name;
        public bool IsFull { get { return EntriesList.Count == MAX_NUMBER_OF_ENTRIES; } }

        private List<ShoppingEntry> _entriesList;
        private List<ShoppingEntry> EntriesList
        {
            get
            {
                _entriesList ??= new List<ShoppingEntry>();
                return _entriesList;
            }
            set { _entriesList = value; }
        }

        public ShoppingList() { }

        public bool AddNewElement(ShoppingEntry newEntry)
        {
            if (EntriesList.Count < MAX_NUMBER_OF_ENTRIES)
            {
                EntriesList.Add(newEntry);
                return true;
            }
            return false;
        }
    }
}
