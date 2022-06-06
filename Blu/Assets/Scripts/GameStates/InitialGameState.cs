﻿using UnityEngine;

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
    }
    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
