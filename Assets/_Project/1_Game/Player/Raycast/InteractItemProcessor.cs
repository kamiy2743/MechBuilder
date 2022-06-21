using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MB
{
    public class InteractItemProcessor : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        private Subject<IInteractable> _observable = new Subject<IInteractable>();

        public InteractItemProcessor()
        {
            _observable
                .Where(_ => InputProvider.Intance.Interact())
                .ThrottleFirst(System.TimeSpan.FromSeconds(1))
                .Subscribe(interactable =>
                {
                    interactable.Interact();
                });
        }

        public void Hit(RaycastHit hit)
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null) return;

            _observable.OnNext(interactable);
        }
    }
}
