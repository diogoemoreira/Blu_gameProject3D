using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableUseItem
{
    private bool opened = false;
    public bool locked = false;
    public string lockedMessage;
    protected override void Execute()
    {
        if (!locked)
        {
            this.StopInteraction();
            if (!opened)
            {
                this.gameObject.GetComponent<Animator>().Play("OpenDoor");
                opened = true;
                this.gameObject.GetComponent<OcclusionPortal>().open = true;
            }
            else
            {
                this.gameObject.GetComponent<Animator>().Play("CloseDoor");
                opened = false;
                this.gameObject.GetComponent<OcclusionPortal>().open = false;
            }
        } else
        {
            SubtitlesManager.instance.DisplaySubtitles(lockedMessage);
        }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
