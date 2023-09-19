using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShoppingList.DataObjects
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

    public class ShoppingEntry
    {
        private bool _isChecked;
        public bool IsChecked { get { return _isChecked; } set { _isChecked = value; } }

        private String _text = String.Empty;
        public String Text { get { return _text; } set { _text = value; } }

        private int _amount;
        public int Amount { get { return _amount; } set { _amount = value; } }

        private MeasurementUnit _measurement = MeasurementUnit.piece;
        public MeasurementUnit Measurement { get { return _measurement; } set { _measurement = value; } }
    }
}
