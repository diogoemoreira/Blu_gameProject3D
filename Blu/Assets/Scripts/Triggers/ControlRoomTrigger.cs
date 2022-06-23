using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && typeof(GoToControlRoomState).IsInstanceOfType(GameStateManager.instance.currentState))
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.CheckBrothersState);
        }
    }
}
