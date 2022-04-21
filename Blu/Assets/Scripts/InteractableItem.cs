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
            Debug.Log("Press E to interact");
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
    }
    void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }
    protected abstract void TriggerInteraction();
}