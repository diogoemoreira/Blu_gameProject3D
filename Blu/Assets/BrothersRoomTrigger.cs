using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrothersRoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && typeof(CheckBrothersRoomState).IsInstanceOfType(GameStateManager.instance.currentState))
        {

        }
    }
}
