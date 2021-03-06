using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class ItemCount
    {
        private const int _minValue = 0;
        private readonly int _maxValue;

        private readonly int _value;

        private const int _defaultMaxValue = 64;

        public static ItemCount Min => _min;
        private static ItemCount _min = new ItemCount(_minValue);

        public ItemCount(int value, int maxValue = _defaultMaxValue)
        {
            if (maxValue <= _minValue)
            {
                throw new System.Exception("最大数が最小数以下です");
            }

            _maxValue = maxValue;

            if (value < _minValue)
            {
                throw new System.Exception("アイテム数が" + _minValue + "より小さいです");
            }
            if (value > maxValue)
            {
                throw new System.Exception("アイテム数が" + _maxValue + "より大きいです");
            }

            _value = value;
        }

        public ItemCount Add(ItemCount add)
        {
            return new ItemCount(_value + add._value, _maxValue);
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}