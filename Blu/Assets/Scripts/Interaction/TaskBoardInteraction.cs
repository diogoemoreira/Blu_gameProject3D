using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoardInteraction : InteractableUseItem
{
    protected void Start()
    {
        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
    }

    private void HandleGameStateChange(GameBaseState state)
    {
        if (state == GameStateManager.instance.InitialState)
        {
            this.StartInteraction();
        }
        else
        {
            this.StopInteraction();
        }
    }
    protected override void Execute()
    {
        GameStateManager.instance.SwitchState(GameStateManager.instance.ControlRoomState);
    }
}
