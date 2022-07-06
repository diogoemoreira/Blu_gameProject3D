using UnityEngine;

public class InitialGameState : GameBaseState
{
    public override void EnterState(GameStateManager gameState)
    {
        GameObject lightGroup = GameObject.FindGameObjectWithTag("NormalLightsGroup");
        Light[] lights = lightGroup.GetComponentsInChildren<Light>();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }

        GameObject emergencyLightGroup = GameObject.FindGameObjectWithTag("EmergencyLightsGroup");
        Light[] emergencyLights = emergencyLightGroup.GetComponentsInChildren<Light>();

        for (int i = 0; i < emergencyLights.Length; i++)
        {
            emergencyLights[i].enabled = false;
        }

        Transform wakeUpTransform = GameObject.Find("BluWakeUp").GetComponent<Transform>();
        GameObject.FindGameObjectWithTag("Player").transform.position = wakeUpTransform.position;

        Journal.instance.SetCurrentTask("- Check the task board in the living room.");
        SubtitlesManager.instance.DisplaySubtitles("I don't know which tasks i have to do today.");
        SubtitlesManager.instance.DisplaySubtitles("I need to go to the living room to check the task board.");

        UIManager.instance.uiKeyDown(UIManager.instance.journalTooltipUI);

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=false;

        GameObject p = GameObject.FindGameObjectWithTag("Player");

        p.GetComponent<Animator>().Play("StandingUp");

        GameObject cam = GameObject.Find("CameraAnim");
        cam.GetComponent<Animator>().SetBool("fade", false);

        cam.GetComponent<Animator>().Play("CameraStandingUp");
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
