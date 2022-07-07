using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickItem : InteractableItem
{
    public string item;
    public string label;

    protected override void TriggerInteraction()
    {
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
        GameManager.instance.AddItem(item);
        PickUpItemToolTip.instance.ShowToolTip(label);
        Destroy(this.gameObject);
    }
}
