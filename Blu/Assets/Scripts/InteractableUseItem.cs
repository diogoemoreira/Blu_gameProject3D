using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableUseItem : InteractableItem
{
    public bool neeedItem;
    public string neededItem;
    protected override void TriggerInteraction()
    {
        if (neeedItem && neededItem != "")
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
            Execute();
        }
    }

    protected abstract void Execute();
}
