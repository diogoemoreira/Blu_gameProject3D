using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    private bool canInteract = false;

    protected virtual void Update()
    {
        if (canInteract)
        {
            if (Input.GetButton("Interact"))
            {
                TriggerInteraction();
                canInteract = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        canInteract = true;
        InteractionManager.instance.DisplayInteractionText(this.gameObject);
    }
    void OnTriggerExit(Collider other)
    {
        canInteract = false;
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
    }
    protected abstract void TriggerInteraction();
}