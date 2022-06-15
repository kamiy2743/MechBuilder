namespace MB
{
    public class ItemID : object
    {
        private static int _min = 0;
        private static int _max = 64;

        private int _value;

        public ItemID(int value)
        {
            if (value < _min)
            {
                throw new System.Exception("ItemIDが" + _min + "より小さいです");
            }
            if (value > _max)
            {
                throw new System.Exception("ItemIDが" + _max + "より大きいです");
            }

            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
