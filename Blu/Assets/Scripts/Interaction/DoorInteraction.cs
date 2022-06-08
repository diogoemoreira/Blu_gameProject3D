using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableUseItem
{
    private bool opened = false;
    protected override void Execute()
    {
        this.StopInteraction();
        if (!opened)
        {
            this.gameObject.GetComponent<Animator>().Play("OpenDoor");
            opened = true;
        } else
        {
            this.gameObject.GetComponent<Animator>().Play("CloseDoor");
            opened = false;
        }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
