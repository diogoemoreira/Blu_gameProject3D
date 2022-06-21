using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    public static VideoIntro instance;
    public VideoPlayer videoPlayer;

    private void Awake() {
        if(instance==null){
            instance=this;
        }
    }

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.E)){
            //if the user presses the "E" key he will skip the video
            nextScene();
        }

        if (videoPlayer.isPlaying == false) {
            if (videoPlayer.time != 0) {
                //if the video is not playing and it already started
                //it means the video ended and so we proceed to the next scene
                nextScene();
            }
        }
    }

    private void nextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  
    
}
