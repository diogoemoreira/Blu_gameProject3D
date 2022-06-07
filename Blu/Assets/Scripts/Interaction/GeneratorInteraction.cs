using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteraction : InteractableUseItem
{
    protected override void Execute()
    {
        GameStateManager.instance.SwitchState(GameStateManager.instance.PowerOutState);
    }
}
