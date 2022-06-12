using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB.Extension
{
    public static class TransfromExt
    {
        public static Transform[] GetChildrenRecursive(this Transform root)
        {
            var result = new List<Transform>();
            GetRecursive(ref result, root);
            return result.ToArray();
        }

        private static void GetRecursive(ref List<Transform> result, Transform root)
        {
            foreach (Transform child in root)
            {
                result.Add(child);
                GetRecursive(ref result, child);
            }
        }
    }
}
