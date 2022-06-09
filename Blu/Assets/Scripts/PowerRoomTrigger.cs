using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameStateManager.instance.currentState == GameStateManager.instance.MachineRoomState && other.tag == "Player")
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.TurnOffPowerState);
        }
    }
}
