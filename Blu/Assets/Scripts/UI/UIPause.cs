using UnityEngine;

public class UIPause : MonoBehaviour, UIInterface
{
    public CanvasGroup canvas;
    public GameObject shade;

    private bool paused = false;

    private void Start() {
        this.gameObject.SetActive(false);
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
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;
        Time.timeScale = 0;
        Data.setPaused(true);
        shade.SetActive(true);
    }

    public void FadeOut(){
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;
        Time.timeScale = 1;
        Data.setPaused(false);
        shade.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ButtonContinue(){
        FadeOut();
        paused = false;
    }

    public void ButtonQuit(){
        Application.Quit();
    }

}