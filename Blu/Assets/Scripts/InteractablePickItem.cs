using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickItem : InteractableItem
{
    public string item;

    protected override void TriggerInteraction()
    {
        Debug.Log("Item pickup: " + item);
    }
}
