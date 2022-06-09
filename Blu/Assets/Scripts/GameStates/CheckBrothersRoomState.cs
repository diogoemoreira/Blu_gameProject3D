using UnityEngine;

public class CheckBrothersRoomState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Go to your brother's room.");
        SubtitlesManager.instance.DisplaySubtitles("The radiation alarm is blinking! I need to warn everyone!");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
