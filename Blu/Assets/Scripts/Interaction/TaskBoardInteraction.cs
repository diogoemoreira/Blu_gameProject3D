using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoardInteraction : InteractableUseItem
{
    protected override void Execute()
    {
        GameStateManager.instance.SwitchState(GameStateManager.instance.ControlRoomState);
    }
}
