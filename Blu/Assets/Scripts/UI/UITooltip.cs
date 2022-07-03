using UnityEngine;

public class UITooltip : MonoBehaviour, UIInterface
{
    public CanvasGroup canvas;

    private bool paused = false;

    private void Start() {
        this.gameObject.SetActive(false);
    }
    public void Activate()
    {
        if(Data.getPaused() && paused){
            ButtonClick();
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
    }

    public void FadeOut(){
        Time.timeScale = 1;
        CameraLockData.setLock(true);
        Data.setPaused(false);
        this.gameObject.SetActive(false);
    }

    public void ButtonClick(){
        paused = false;
        UIManager.instance.Reset();
        FadeOut();
    }

}