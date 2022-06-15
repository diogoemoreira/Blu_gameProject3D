using UnityEngine;

public class SearchFamilyState : GameBaseState
{
    private float startTime;
    private float timeBeforePassOut = 15.0f;
    private bool respawned = false;
    private bool fadeProcessStarted = false;
    public override void EnterState(GameStateManager gameState)
    {
        Journal.instance.SetCurrentTask("- Search for your family.");
        SubtitlesManager.instance.DisplaySubtitles("Where is everyone?");
        startTime = Time.time;
        HeartRateManager.instance.respawnEvent.AddListener(Respawned);
    }
    public override void UpdateState(GameStateManager gameState)
    {
        if (respawned)
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.CheckMainDoorState);
        }
        if (Time.time > startTime + timeBeforePassOut)
        {
            if (!fadeProcessStarted)
            {
                fadeProcessStarted = true;
                SubtitlesManager.instance.DisplaySubtitles("Father?");
                SubtitlesManager.instance.DisplaySubtitles("Mother?");
                SubtitlesManager.instance.DisplaySubtitles("Brother?");
                SubtitlesManager.instance.DisplaySubtitles("Where... Where are you?");
            }
            HeartRateManager.instance.ForceMultiplier(7);
        }    
    }

    private void Respawned()
    {
        respawned = true;
    }
}
