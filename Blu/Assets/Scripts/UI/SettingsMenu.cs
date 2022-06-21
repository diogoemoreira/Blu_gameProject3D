using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

    private void Start() {
        resolutions = Screen.resolutions;

        fullscreenToggle.isOn=Screen.fullScreen;
    
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;
        for(int i=0; i<resolutions.Length; i++){
            //for every available resolution add it to the list of options
            string option = resolutions[i].width+" x "+resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && 
                resolutions[i].height == Screen.height)
            { //confirm what is the current resolution of the game
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //add the resolution options to the dropdown
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue(); //refresh shown value
    }

    public void SetVolume(float volume){
        //this float should go from min -80 to max 0 (this is due to the volume mixer)
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void setFullscreen(bool isFullscreen){
        //just change fullscreen
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //change the resolution (and apply fullscreen if enabled)
    }
}

