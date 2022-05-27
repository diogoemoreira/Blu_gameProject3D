using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIPause pauseUI = null;

    static bool paused=false;
    static bool lock_interface = false;
    static bool justChanged = false;
    UIInterface ui = null;

    // Update is called once per frame
    void Update()
    {
        if(!lock_interface)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (!justChanged)
                {
                    if (paused)
                    {
                        if (ui != null)
                        {
                            ui.Activate();
                            ui = null;
                            paused = false;
                        }
                    }
                    else
                    {
                        CheckKeyDown();
                    }
                }
                else
                {
                    justChanged = false;
                }
            }
        }
    }

    void CheckKeyDown(){
        pauseUI.Activate();
        paused= true;
        ui = (UIInterface) pauseUI;
    }

    public static void LockInterfaces(){
        lock_interface = true;
        justChanged = true;
    }

    public static void UnlockInterfaces(){
        lock_interface = false;
        justChanged = true;
    }

    public static bool IsPaused()
    {
        return paused;
    }
}
