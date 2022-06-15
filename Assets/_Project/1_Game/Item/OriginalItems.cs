using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class OriginalItems : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private OriginalItemsConfig _config;

        private IItem[] _originalItems;

        public void StaticAwake()
        {
            var originalItems = new List<IItem>();
            for (int i = 0; i < _config.ItemObjects.Length; i++)
            {
                var itemObject = _config.ItemObjects[i];
                var obj = itemObject.Object;
                if (!obj.TryGetComponent(out IItem _))
                {
                    Debug.LogError("Itemじゃない");
                    continue;
                }

                var originalObj = Instantiate(obj);
                originalObj.SetActive(false);
                originalObj.transform.SetParent(this.transform);

                var originalItem = originalObj.GetComponent<IItem>();
                var itemID = i;
                var name = itemObject.Name;
                originalItem.Initialize(itemID, name);
                originalItems.Add(originalItem);
            }

            _originalItems = originalItems.ToArray();
        }
    }
}
