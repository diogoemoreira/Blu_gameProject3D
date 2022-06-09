using UnityEngine;

public class EnterMachineRoomState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Enter the machine room.");
        SubtitlesManager.instance.DisplaySubtitles("Okay so i need to go to the machine room so that i can turn off the power.");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
