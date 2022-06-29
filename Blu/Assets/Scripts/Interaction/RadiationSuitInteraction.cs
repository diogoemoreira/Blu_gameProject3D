using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationSuitInteraction : InteractableUseItem
{
    protected void Start()
    {
        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
    }

    private void HandleGameStateChange(GameBaseState state)
    {
        if (state == GameStateManager.instance.PickUpSuitState)
        {
            this.StartInteraction();
        } else
        {
            this.StopInteraction();
        }
    }

    protected override void Execute()
    {
        GameStateManager.instance.SwitchState(GameStateManager.instance.CheckMainDoorState);
        Destroy(this.gameObject);
    }
}
