using UnityEngine;
using System.Collections;

public class PickUpSuitState : GameBaseState
{

    public override void EnterState(GameStateManager gameState)
    {
        GameObject cam = GameObject.FindGameObjectWithTag("CameraAnim");
        Animator camAnim = cam.GetComponent<Animator>();


        camAnim.SetBool("fade", false);
        camAnim.Play("CameraFadeIn");

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=false;
    }

    public override void UpdateState(GameStateManager gameState)
    {
        
    }
}
