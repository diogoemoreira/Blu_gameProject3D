using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorInteraction : InteractableUseItem
{
    private bool opened = false;
    private bool checkState = false;

    protected void Start()
    {
        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
    }

    private void HandleGameStateChange(GameBaseState state)
    {
        checkState = false;
        if (state == GameStateManager.instance.CheckMainDoorState)
        {
            this.StartInteraction();
            checkState = true;
        }
        else
        {
            this.StopInteraction();
        }
    }
    protected override void Execute()
    {
        /**
        this.StopInteraction();
        if (!opened)
        {
            this.gameObject.GetComponent<Animator>().Play("OpenDoor");
            opened = true;
        } else
        {
            this.gameObject.GetComponent<Animator>().Play("CloseDoor");
            opened = false;
        }**/

        if (checkState)
        {
            SubtitlesManager.instance.DisplaySubtitles("The door is locked...My brother had the key card.");
            GameStateManager.instance.SwitchState(GameStateManager.instance.DoorManualState);
        }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
