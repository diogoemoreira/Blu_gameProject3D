using UnityEngine;

public class UIPause : MonoBehaviour, UIInterface
{
    public CanvasGroup canvas;
    public GameObject shade;

    private bool paused = false;

    public static UIPause instance {get; private set; }

    private void Start() {
        this.gameObject.SetActive(false);

        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
        }
    }
    public void Activate()
    {
        if(Data.getPaused() && paused){
            FadeOut();
            paused = false;
        }
        else if(!Data.getPaused()){
            FadeIn();
            paused = true;
        }
    }

    public void FadeIn(){
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        CameraLockData.setLock(false);
        Data.setPaused(true);
        shade.SetActive(true);
    }

    public void FadeOut(){
        Time.timeScale = 1;
        CameraLockData.setLock(true);
        Data.setPaused(false);
        shade.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ButtonContinue(){
        FadeOut();
        paused = false;
        UIManager.instance.Reset();
    }

    public void ButtonQuit(){
        Application.Quit();
    }

}