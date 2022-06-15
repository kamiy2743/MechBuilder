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
                var obj = _config.ItemObjects[i];
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
                originalItem.Initialize(itemID);
                originalItems.Add(originalItem);
            }

            _originalItems = originalItems.ToArray();
        }
    }
}
