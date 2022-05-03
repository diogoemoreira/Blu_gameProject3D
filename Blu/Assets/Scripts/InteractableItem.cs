using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    private bool canInteract = true;
    void OnTriggerEnter(Collider other)
    {
        if (canInteract)
        {
            InteractionManager.instance.DisplayInteractionText(this.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
    }

    public void Interact()
    {
        TriggerInteraction();
    }

    protected void StopInteraction()
    {
        canInteract = false;
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
    }

    protected abstract void TriggerInteraction();
}