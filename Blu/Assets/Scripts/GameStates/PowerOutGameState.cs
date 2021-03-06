using UnityEngine;

public class PowerOutGameState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        GameObject lightGroup = GameObject.FindGameObjectWithTag("NormalLightsGroup");
        Light[] lights = lightGroup.GetComponentsInChildren<Light>();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }

        GameObject emergencyLightGroup = GameObject.FindGameObjectWithTag("EmergencyLightsGroup");
        Light[] emergencyLights = emergencyLightGroup.GetComponentsInChildren<Light>();

        for (int i = 0; i < emergencyLights.Length; i++)
        {
            emergencyLights[i].enabled = true;
        }

        GameObject[] doorsToOpen = GameObject.FindGameObjectsWithTag("DoorKeyCardPowerOff");

        for (int i=0;i< doorsToOpen.Length; i++)
        {
            doorsToOpen[i].GetComponent<DoorInteraction>().locked = false;
        }  

        SubtitlesManager.instance.DisplaySubtitles("Ok, so whats next? Hmmm, yes open the door terminal.");
        Journal.instance.SetCurrentTask("- Open the bunker door.");

        //flashlight now usable
        Flashlight.instance.flashUsable();
        
        UIManager.instance.uiKeyDown(UIManager.instance.flashTooltipUI);
        //
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
