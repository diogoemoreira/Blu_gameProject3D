using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        InteractionManager.instance.DisplayInteractionText(this.gameObject);
    }
    void OnTriggerExit(Collider other)
    {
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
    }

    public void Interact()
    {
        TriggerInteraction();
    }

    protected abstract void TriggerInteraction();
}