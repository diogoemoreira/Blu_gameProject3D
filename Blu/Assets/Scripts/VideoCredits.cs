using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoCredits : MonoBehaviour
{
    public static VideoCredits instance;
    public VideoPlayer videoPlayer;
    public GameObject mainMenu;
    public GameObject creditsMenu;

    private bool videoStarted=false;

    private void Awake() {
        if(instance==null){
            instance=this;
        }
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.E)){
            //if the user presses the "E" key he will skip the video
            endVideo();
        }

        if (!videoStarted && videoPlayer.isPlaying == true) {
            mainMenu.SetActive(false);
            videoStarted=true;
        }

        if (videoPlayer.isPlaying == false) {
            if (videoPlayer.time != 0) {
                //if the video is not playing and it already started
                //it means the video ended and so we proceed to the next scene
                endVideo();
            }
        }
    }

    

    private void endVideo(){
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }  
    
}
