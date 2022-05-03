using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUseItem : InteractableItem
{

    protected override void TriggerInteraction()
    {
        Debug.Log("Use");
    }
}
