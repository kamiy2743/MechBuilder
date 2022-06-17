using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MB
{
    public class PlayerInventory : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private InventorySlot _slotPrefab;
        [SerializeField] private Transform _slotParent;

        public IInventoryItem ItemInHand => Get(0, 0);

        InventoryGrid _grid;
        private IInventoryItem[] _items;
        private InventorySlot[] _slots;

        public static PlayerInventory Instance => _instance;
        private static PlayerInventory _instance;

        public void StaticAwake()
        {
            _instance = this;

            _grid = new InventoryGrid(4, 9);
            _items = new IInventoryItem[_grid.Count];
            _slots = new InventorySlot[_grid.Count];

            for (int i = 0; i < _grid.Count; i++)
            {
                _items[i] = InventoryItem.Empty;

                var slot = Instantiate(_slotPrefab.gameObject, parent: _slotParent).GetComponent<InventorySlot>();
                _slots[i] = slot;

                slot.SetItemID(_items[i].ID);
                slot.SetItemCount(_items[i].Count);
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

            var index = _grid.ToIndex(row, column);
            _items[index] = item;

            // TODO どこかで値の変化を監視
            _slots[index].SetItemID(item.ID);
            _slots[index].SetItemCount(item.Count);

            return true;
        }

        private bool IsEmpty(int row, int column)
        {
            var item = Get(row, column);
            return item == InventoryItem.Empty;
        }
    }
}
