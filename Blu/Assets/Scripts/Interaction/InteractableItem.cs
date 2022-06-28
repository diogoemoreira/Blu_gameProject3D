using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    private bool canInteract = true;
    private bool onColider = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canInteract)
        {
            InteractionManager.instance.DisplayInteractionText(this.gameObject);
            onColider = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InteractionManager.instance.StopDisplayInteractText(this.gameObject);
            onColider = false;
        }
    }

    public void Interact()
    {
        TriggerInteraction();
    }

    public void StopInteraction()
    {
        canInteract = false;
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
    }

    public void StartInteraction()
    {
        canInteract = true;
        if (onColider) {
            InteractionManager.instance.DisplayInteractionText(this.gameObject);
        }
    }

    protected abstract void TriggerInteraction();
}