using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    [CreateAssetMenu(fileName = "OriginalItemConfig", menuName = "ScriptableObjects/OriginalItemConfig")]
    public class OriginalItemsConfig : ScriptableObject
    {
        [Header("並び順がItemIDになる")]
        public ItemPrefab[] Prefabs;
    }

    [System.Serializable]
    public class ItemPrefab
    {
        public string Name;
        public GameObject GameObject;
    }
}
