using UnityEngine;

public class TurnOffPowerState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Turn off the power.");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
