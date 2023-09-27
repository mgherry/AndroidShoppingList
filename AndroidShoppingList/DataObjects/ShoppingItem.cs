using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShoppingList.ScreenDisplays
{
    public enum MeasurementUnit
    {
        piece,

        g,
        dkg,
        kg,

        ml,
        dl,
        l
    }

    public class ShoppingItem : BindableObject
    {
        // Can't be static as the Data Binding wouldn't work with that
        public List<string> MeasurementUnitNames { get { return Enum.GetNames(typeof(MeasurementUnit)).ToList(); } }

        private bool _isCompleted;
        public bool IsCompleted { 
            get { return _isCompleted; } 
            set { _isCompleted = value; OnPropertyChanged(nameof(IsCompleted)); } 
        }

        private String _itemDescription = String.Empty;
        public String ItemDescription { get { return _itemDescription; } set { _itemDescription = value; OnPropertyChanged(nameof(ItemDescription)); } }

        private int _amount;
        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(nameof(Amount)); } }

        private MeasurementUnit _measurement;
        public MeasurementUnit Measurement { get { return _measurement; } set { _measurement = value; OnPropertyChanged(nameof(Measurement)); } }

        public ShoppingItem()
        {
            Measurement = MeasurementUnit.piece; // Later TODO: Recieve default Measurement from Settings
        }
    }
}
