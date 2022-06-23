using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameStateManager.instance.currentState == GameStateManager.instance.DoorManualState && other.tag == "Player")
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.MachineRoomState);
        }
    }
}
