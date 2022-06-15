using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class OriginalItems : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private OriginalItemsConfig _config;

        private Dictionary<ItemID, IFieldItem> _originalItems = new Dictionary<ItemID, IFieldItem>();

        public void StaticAwake()
        {
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

                _originalItems[itemID] = originalItem;
            }

            Instantiate(new ItemID(0));
        }

        public IFieldItem Instantiate(ItemID itemID, Transform parent = null)
        {
            var originalItem = _originalItems[itemID];
            var p = parent ??= this.transform.parent;

            var item =
                Instantiate(originalItem.GameObject, parent: p)
                .GetComponent<IFieldItem>();

            item.Initialize(itemID);
            item.GameObject.SetActive(true);

            return item;
        }
    }
}
