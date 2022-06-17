namespace MB
{
    public class ItemID
    {
        private const int _minValue = 0;
        private const int _maxValue = 64;

        private readonly int _value;

        public static ItemID EmptyID => _emptyID;
        private static ItemID _emptyID = new ItemID(-999);

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
    }
}
