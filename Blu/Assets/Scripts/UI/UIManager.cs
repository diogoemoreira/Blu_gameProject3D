using UnityEngine;

public class UIManager : MonoBehaviour
{
    //singleton can be read from other scripts but only set within its own class
    public static UIManager instance {get; private set; }
    //
    
    public UIPause pauseUI = null;
    bool paused=false;

    //control variables
    bool lock_interface = false;
    bool justChanged = false;
    //

    UIInterface ui = null;

    private void Start() {
        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }

    // Update is called once per frame
    void Update() {
        //confirm if the interface isn't locked and the cancel button was pressed
        if(!lock_interface && Input.GetButtonDown("Cancel")) {
            //confirm if control variables werent just changed
            if (!justChanged) {
                if (paused) {
                    if (ui != null){
                        ActivateInterface();
                        ui = null;
                        paused = false;
                    }
                }
                else {
                    CheckKeyDown();
                }
            }
            else {
                justChanged = false;
            }
        }
    }

    void CheckKeyDown(){
        pauseUI.Activate();
        paused= true;
        ui = (UIInterface) pauseUI;
    }

    public void LockInterfaces(){
        instance.lock_interface = true;
        instance.justChanged = true;
    }

    public void UnlockInterfaces(){
        instance.lock_interface = false;
        instance.justChanged = true;
    }

    public bool IsPaused()
    {
        return instance.paused;
    }

    public void ActivateInterface(){
        ui.Activate();
    }

    public void Reset(){
        ui = null;
        paused = false;
    }
}
