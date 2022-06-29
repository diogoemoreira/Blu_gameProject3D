using UnityEngine;

public class CheckMainDoorState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Go to the main door.");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
