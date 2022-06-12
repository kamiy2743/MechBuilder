using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MB
{
    public class CommonUI : MonoBehaviour, IStaticAwake
    {
        private CanvasGroup _canvasGroup;

        public void StaticAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public async UniTask ShowAsync(float fadeDuration)
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(1, fadeDuration);
        }

        public async UniTask HideAsync(float fadeDuration)
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            _canvasGroup.DOKill();
            await _canvasGroup.DOFade(0, fadeDuration);
        }
    }
}
