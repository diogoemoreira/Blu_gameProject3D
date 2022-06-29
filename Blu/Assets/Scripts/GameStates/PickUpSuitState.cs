using UnityEngine;

public class PickUpSuitState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Pick up your radiation suit on your room.");
        SubtitlesManager.instance.DisplaySubtitles("They probably left. I need to go after them!");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
