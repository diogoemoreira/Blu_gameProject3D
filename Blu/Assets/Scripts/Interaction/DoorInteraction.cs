using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableUseItem
{
    private bool opened = false;
    public bool locked = false;
    public string lockedMessage;

    public AudioSource openDoorSound;
    public AudioSource closeDoorSound;
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
                openDoorSound.Play();
            }
            else
            {
                this.gameObject.GetComponent<Animator>().Play("CloseDoor");
                opened = false;
            }
        } else
        {
            SubtitlesManager.instance.DisplaySubtitles(lockedMessage);
        }
    }

    public void AnimationOver()
    {
        if (!opened)
        {
            this.gameObject.GetComponent<OcclusionPortal>().open = false;
        }
        this.StartInteraction();
    }

    public void PlayCloseSound()
    {
        closeDoorSound.Play();
    }
}
