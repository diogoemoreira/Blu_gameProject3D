using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnimController : MonoBehaviour
{
    private GameObject camParent;
    private GameObject cam;
    private Animator camAnim;

    private void Awake() {
        camParent = GameObject.Find("CameraAnim");
        cam = GetComponentInChildren<Camera>().gameObject;
        camAnim = camParent.GetComponent<Animator>();
    }

    public void pickSuitTask(){
        HeartBeatUI.instance.gameObject.SetActive(true);
        UIManager.instance.uiKeyDown(UIManager.instance.heartbeatTooltipUI);

        Journal.instance.SetCurrentTask("- Pick up your radiation suit on your room.");
        SubtitlesManager.instance.DisplaySubtitles("They probably left. I need to go after them!");

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=true;
        
        camAnim.SetBool("fade", true);
    }

    public void initialTask(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=true;
        
        camAnim.SetBool("fade", true);
    }

    public void FadedOut()
    {
        HeartRateManager.instance.FadedOut();
    }

    public void Crouching(){
        camAnim.SetBool("crouching", true);
    }

    public void NotCrouching(){
        camAnim.SetBool("crouching", false);
    }
}
