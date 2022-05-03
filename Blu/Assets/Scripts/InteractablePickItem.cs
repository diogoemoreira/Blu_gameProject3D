using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickItem : InteractableItem
{
    public string item;

    protected override void TriggerInteraction()
    {
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
        GameManager.instance.AddItem(item);
        Destroy(this.gameObject);
    }
}
