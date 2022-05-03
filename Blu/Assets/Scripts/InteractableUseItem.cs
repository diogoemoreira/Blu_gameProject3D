using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableUseItem : InteractableItem
{
    public string neededItem;
    protected override void TriggerInteraction()
    {
        if (neededItem != null)
        {
            if (GameManager.instance.CheckForItem(neededItem))
            {
                Execute();
            } else
            {
                Debug.Log("Dont have item");
            }
        } else
        {
            Debug.Log("Can use without any item");
        }
    }

    protected abstract void Execute();
}
