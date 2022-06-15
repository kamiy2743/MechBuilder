using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    [CreateAssetMenu(fileName = "ItemPrefabsConfig", menuName = "ScriptableObjects/ItemPrefabsConfig")]
    public class OriginalItemsConfig : ScriptableObject
    {
        [Header("並び順がItemIDになる")]
        public ItemObject[] ItemObjects;
    }

    [System.Serializable]
    public class ItemObject
    {
        public string Name;
        public GameObject Object;
    }
}
