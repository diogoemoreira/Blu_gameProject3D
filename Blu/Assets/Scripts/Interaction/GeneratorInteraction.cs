using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteraction : InteractableUseItem
{
    protected void Start()
    {
        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
    }

    private void HandleGameStateChange(GameBaseState state)
    {
        if (state == GameStateManager.instance.TurnOffPowerState)
        {
            this.StartInteraction();
        } else
        {
            this.StopInteraction();
        }
    }

    protected override void Execute()
    {
        GameStateManager.instance.SwitchState(GameStateManager.instance.PowerOutState);
    }
}
