using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount
{
    private const int _min = 0;

    public int Value { get; }
    private readonly int _max;

    private const int _defaultMax = 64;

    public ItemCount(int value, int max = _defaultMax)
    {
        if (max <= _min)
        {
            throw new System.Exception("最大数が最小数以下です");
        }

        _max = max;

        if (value < _min)
        {
            throw new System.Exception("アイテム数が" + _min + "より小さいです");
        }
        if (value > max)
        {
            throw new System.Exception("アイテム数が" + _max + "より大きいです");
        }

        Value = value;
    }

    public ItemCount(int max = _defaultMax)
    {
        _max = max;
        Value = _min;
    }

    public ItemCount Add(ItemCount add)
    {
        return new ItemCount(Value + add.Value, _max);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
