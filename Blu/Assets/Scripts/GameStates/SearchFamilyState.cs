using UnityEngine;

public class SearchFamilyState : GameBaseState
{
    private float startTime;
    private float timeBeforePassOut = 15.0f;
    private bool respawned = false;
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
            HeartRateManager.instance.ForceMultiplier(20);
        }    
    }

    private void Respawned()
    {
        respawned = true;
    }
}
