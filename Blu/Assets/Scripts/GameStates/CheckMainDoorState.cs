using UnityEngine;

public class CheckMainDoorState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Go to the main door.");
        SubtitlesManager.instance.DisplaySubtitles("They probably left. I need to go after them!");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
