using UnityEngine;

public class GoToControlRoomState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Go to the control room\n\t- Check the panel.");
        SubtitlesManager.instance.DisplaySubtitles("I need to go to the control room.");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
