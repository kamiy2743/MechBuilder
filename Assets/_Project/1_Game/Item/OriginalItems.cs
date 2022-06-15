using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class OriginalItems : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private OriginalItemsConfig _config;

        private OriginalItem[] _originalItems;

        public void StaticAwake()
        {
            var originalItems = new List<OriginalItem>();
            for (int i = 0; i < _config.ItemObjects.Length; i++)
            {
                var itemObject = _config.ItemObjects[i];
                if (!itemObject.GameObject.TryGetComponent(out IItem _))
                {
                    Debug.LogError("Itemじゃない");
                    continue;
                }

                var go = Instantiate(itemObject.GameObject);
                go.SetActive(false);
                go.transform.SetParent(this.transform);

                var item = go.GetComponent<IItem>();
                var itemID = new ItemID(i);
                var name = itemObject.Name;
                item.Initialize(itemID, name);

                var originalItem = new OriginalItem(go, item);
                originalItems.Add(originalItem);
            }

            _originalItems = originalItems.ToArray();
        }

        private class OriginalItem
        {
            public GameObject GameObject;
            public IItem Item;

            public OriginalItem(GameObject go, IItem item)
            {
                GameObject = go;
                Item = item;
            }
        }
    }
}
