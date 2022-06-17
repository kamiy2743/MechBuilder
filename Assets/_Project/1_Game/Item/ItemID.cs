using UnityEngine;

namespace MB
{
    public class ItemID
    {
        private const int _minValue = 0;
        private const int _maxValue = 64;

        private readonly int _value;

        public static ItemID EmptyID => _emptyID;
        private static ItemID _emptyID = new ItemID(_minValue);

        public ItemID(int value)
        {
            if (value < _minValue)
            {
                throw new System.Exception("ItemIDが" + _minValue + "より小さいです");
            }
            if (value > _maxValue)
            {
                throw new System.Exception("ItemIDが" + _maxValue + "より大きいです");
            }

            if (value == _maxValue)
            {
                Debug.LogWarning("ItemID: " + _maxValue + " は空のIDを意味します");
            }

            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static bool operator ==(ItemID id1, ItemID id2)
        {
            return id1._value == id2._value;
        }

        public static bool operator !=(ItemID id1, ItemID id2)
        {
            return !(id1 == id2);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (ItemID)obj;
            return _value == other._value;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
