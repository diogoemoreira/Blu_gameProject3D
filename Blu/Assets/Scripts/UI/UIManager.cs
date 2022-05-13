using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIPause pauseUI = null;

    bool paused=false;
    UIInterface ui = null;

    // Update is called once per frame
    void Update()
    {
        if (paused && Input.GetKeyDown(KeyCode.Escape)){
            if(ui!=null){
                ui.Activate();
                ui = null;
                paused = false;
            }
        }
        else{
            CheckKeyDown();
        }
    }

    void CheckKeyDown(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseUI.Activate();
            paused= !paused;
            ui = (UIInterface) pauseUI;
        }
    }
}
