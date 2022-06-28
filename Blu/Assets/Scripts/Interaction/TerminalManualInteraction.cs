using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalManualInteraction : InteractableUseItem
{
    public Sprite manualSprite;

    protected override void Execute()
    {
        ReadPaper.instance.ShowPaper(manualSprite);
        if (GameStateManager.instance.currentState == GameStateManager.instance.DoorManualState)
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.TurnOffPowerState);
        }
    }
}
