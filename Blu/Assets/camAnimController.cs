using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camAnimController : MonoBehaviour
{
    public void pickSuitTask(){
        HeartBeatUI.instance.gameObject.SetActive(true);
        UIManager.instance.uiKeyDown(UIManager.instance.heartbeatTooltipUI);

        Journal.instance.SetCurrentTask("- Pick up your radiation suit on your room.");
        SubtitlesManager.instance.DisplaySubtitles("They probably left. I need to go after them!");

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled=true;
        GameObject cam = GameObject.Find("CameraAnim");
        cam.GetComponent<Animator>().SetBool("fade", true);
    }
}
