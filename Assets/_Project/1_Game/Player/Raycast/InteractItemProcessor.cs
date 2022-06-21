using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MB
{
    public class InteractItemProcessor : IRaycasterStateProcessor
    {
        public int LayerMask { get; private set; } = (1 << UnityEngine.LayerMask.NameToLayer("Item"));

        public void Hit(RaycastHit hit)
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable == null) return;

            if (InputProvider.Intance.Interact())
            {
                interactable.Interact();
            }
        }
    }
}
