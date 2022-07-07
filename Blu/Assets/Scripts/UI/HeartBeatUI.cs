using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class HeartBeatUI : MonoBehaviour
{
    public Image heartBeatImage;
    public Text hearRateText;
    public static HeartBeatUI instance;

    private bool increasingSize = false;
    private Vector3 maxSize = new Vector3(1f, 1f, 1f);
    private Vector3 minSize = new Vector3(0.8f, 0.8f, 0.8f);
    private float rate;
    private float post_processing_value;
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        rate = 20f;

        this.gameObject.SetActive(false);

        // Post processing enable:
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);

        vignette.active = true;
        vignette.intensity.value = 0;

        chromaticAberration.active = true;
        chromaticAberration.intensity.value = 0;
    }

    private void Update()
    {
        if (heartBeatImage != null)
        {
            if (increasingSize)
            {
                heartBeatImage.transform.localScale = Vector3.Lerp(heartBeatImage.transform.localScale, maxSize, Time.deltaTime * rate);
                // too fast for vignette ->
                //vignette.intensity.value = Mathf.Lerp(rate / 100.0f, rate / 100.0f + 0.2f, Time.deltaTime * rate);
                if (heartBeatImage.transform.localScale == maxSize)
                {
                    increasingSize = false;
                }
            }
            else
            {
                heartBeatImage.transform.localScale = Vector3.Lerp(heartBeatImage.transform.localScale, minSize, Time.deltaTime * (rate*0.7f));
                // too fast for vignette ->
                //vignette.intensity.value = Mathf.Lerp(rate / 100.0f + 0.2f, rate / 100.0f, Time.deltaTime * rate);
                if (heartBeatImage.transform.localScale == minSize)
                {
                    increasingSize = true;
                }
            }
        }

        // Change vignette intensity using a sinus curve & add Chromatic Aberration 
        int slow_speed = 5, fast_speed = 10; // check these values please, maybe my framerate affects the heart speed

        if (rate > 170)
            vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * fast_speed) / 2.0f + 0.5f;
        else if (rate > 120)
        {
            vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup * slow_speed) / 2.0f + 0.5f;
            chromaticAberration.intensity.value = 0.5f;
        }
        else
            vignette.intensity.value = 0;

    }

    public void UpdateHeartBeat(int heartBeat)
    {
        hearRateText.text = heartBeat + " BPM";
        if (heartBeat < 100)
        {
            rate = 20f;
        } else if (heartBeat < 120)
        {
            rate = 40f;
        } else if (heartBeat < 150)
        {
            rate = 60f;
        }
        else if (heartBeat < 200)
        {
            rate = 80f;
        }
    }
}
