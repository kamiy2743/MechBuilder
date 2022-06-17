using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class OriginalFieldItems : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private OriginalFieldItemsConfig _config;

        private Dictionary<string, IFieldItem> _originalItems = new Dictionary<string, IFieldItem>();

        public static OriginalFieldItems Instance => _instance;
        private static OriginalFieldItems _instance;

        public void StaticAwake()
        {
            _instance = this;

            for (int i = 0; i < _config.Prefabs.Length; i++)
            {
                var prefab = _config.Prefabs[i];
                if (!prefab.GameObject.TryGetComponent(out IFieldItem _))
                {
                    Debug.LogError("IFieldItemじゃない");
                    continue;
                }

                var originalItem =
                    Instantiate(prefab.GameObject, parent: this.transform)
                    .GetComponent<IFieldItem>();

                var itemID = new ItemID(i);
                originalItem.Initialize(itemID);
                originalItem.GameObject.name = prefab.GameObject.name;
                originalItem.GameObject.SetActive(false);

                Set(itemID, originalItem);
            }

            Instantiate(new ItemID(0));
        }

        public IFieldItem Instantiate(ItemID itemID, Transform parent = null)
        {
            var originalItem = Get(itemID);
            var p = parent ??= this.transform.parent;

            var item =
                Instantiate(originalItem.GameObject, parent: p)
                .GetComponent<IFieldItem>();

            item.Initialize(itemID);
            item.GameObject.SetActive(true);

            return item;
        }

        public IReadOnlyFieldItem GetOriginalData(ItemID itemID)
        {
            return _originalItems[itemID.ToString()];
        }

        private IFieldItem Get(ItemID itemID)
        {
            return _originalItems[itemID.ToString()];
        }

        private void Set(ItemID itemID, IFieldItem originalItem)
        {
            _originalItems[itemID.ToString()] = originalItem;
        }
    }
}
