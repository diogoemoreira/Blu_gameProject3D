using UnityEngine;
using System.Collections;

public class PickUpSuitState : GameBaseState
{

    public override void EnterState(GameStateManager gameState)
    {
        GameObject cam = GameObject.Find("CameraAnim");
        cam.GetComponent<Animator>().SetBool("fade", false);
        cam.GetComponent<Animator>().Play("CameraFadeIn");

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=false;
    }

    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
