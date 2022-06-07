using UnityEngine;

public class SearchFamilyState : GameBaseState
{
    private float startTime;
    private float timeBeforePassOut = 30.0f;
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Search for your family.");
        SubtitlesManager.instance.DisplaySubtitles("Where is everyone?");
        startTime = Time.time;
    }
    public override void UpdateState(GameStateManager gameState)
    {
        if (Time.time > startTime + timeBeforePassOut)
        {
            
        }    
    }
}
