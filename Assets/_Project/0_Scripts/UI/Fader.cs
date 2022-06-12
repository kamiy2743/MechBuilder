using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MB
{
    public class Fader : MonoBehaviour, IStaticAwake
    {
        public static Fader Instance => _instance;
        private static Fader _instance;

        private CommonUI _commonUI;

        public void StaticAwake()
        {
            _instance = this;
            _commonUI = GetComponent<CommonUI>();
        }

        public async UniTask FadeInAsync(float duration)
        {
            await _commonUI.HideAsync(duration);
        }

        public async UniTask FadeOutAsync(float duration)
        {
            await _commonUI.ShowAsync(duration);
        }
    }
}
