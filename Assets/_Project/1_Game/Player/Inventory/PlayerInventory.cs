using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MB
{
    public class PlayerInventory : MonoBehaviour, IStaticAwake
    {
        InventoryGrid _grid;
        private IInventoryItem[] _items;

        public void StaticAwake()
        {
            _grid = new InventoryGrid(4, 9);
            _items = new IInventoryItem[_grid.Count];

            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = InventoryItem.Empty;
            }
        }

        public IInventoryItem Get(int row, int column)
        {
            return _items[_grid.ToIndex(row, column)];
        }

        /// <returns>Success</returns>
        public bool Set(int row, int column, IInventoryItem item, bool force = false)
        {
            if (!IsEmpty(row, column))
            {
                if (!force)
                {
                    return false;
                }
            }

            _items[_grid.ToIndex(row, column)] = item;
            return true;
        }

        private bool IsEmpty(int row, int column)
        {
            var item = Get(row, column);
            return item == InventoryItem.Empty;
        }
    }
}
