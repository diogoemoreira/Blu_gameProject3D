using UnityEngine;

public class FindDoorManualState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Find the terminal manual in the control room.");
        SubtitlesManager.instance.DisplaySubtitles("Maybe i can open the door without the keycard.");
        SubtitlesManager.instance.DisplaySubtitles("If there is any information about this it might be in the control room.");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
