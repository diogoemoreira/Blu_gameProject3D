using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIPause pauseUI = null;

    bool paused=false;
    static bool lock_interface = false;
    UIInterface ui = null;

    // Update is called once per frame
    void Update()
    {
        if(!lock_interface){
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
    }

    void CheckKeyDown(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseUI.Activate();
            paused= !paused;
            ui = (UIInterface) pauseUI;
        }
    }

    public static void LockInterfaces(){
        lock_interface = true;
    }

    public static void UnlockInterfaces(){
        lock_interface = false;
    }
}
