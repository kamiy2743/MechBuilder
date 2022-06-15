using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class OriginalItems : MonoBehaviour, IStaticAwake
    {
        [SerializeField] private OriginalItemsConfig _config;

        private IFieldItem[] _originalItems;

        public void StaticAwake()
        {
            var originalItems = new List<IFieldItem>();

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

                originalItem.GameObject.SetActive(false);
                originalItem.Initialize(new ItemID(i));

                originalItems.Add(originalItem);
            }

            _originalItems = originalItems.ToArray();
        }
    }
}
