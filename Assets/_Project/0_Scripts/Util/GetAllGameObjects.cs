using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MB.Extension;

namespace MB
{
    public static class GetAllGameObjects
    {
        public static GameObject[] InActiveScene()
        {
            var gameObjects = new List<GameObject>();

            var scene = SceneManager.GetActiveScene();
            foreach (var root in scene.GetRootGameObjects())
            {
                gameObjects.Add(root);

                var children = root.transform.GetChildrenRecursive();
                foreach (var child in children)
                {
                    gameObjects.Add(child.gameObject);
                }
            }

            return gameObjects.ToArray();
        }
    }
}
