using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatUI : MonoBehaviour
{
    public Image heartBeatImage;
    public Text hearRateText;
    public static HeartBeatUI instance;

    private bool increasingSize = false;
    private Vector3 maxSize = new Vector3(1f, 1f, 1f);
    private Vector3 minSize = new Vector3(0.8f, 0.8f, 0.8f);
    private float rate;

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
    }

    private void Update()
    {
        if (heartBeatImage != null)
        {
            if (increasingSize)
            {
                heartBeatImage.transform.localScale = Vector3.Lerp(heartBeatImage.transform.localScale, maxSize, Time.deltaTime * rate);

                if (heartBeatImage.transform.localScale == maxSize)
                {
                    increasingSize = false;
                }
            }
            else
            {
                heartBeatImage.transform.localScale = Vector3.Lerp(heartBeatImage.transform.localScale, minSize, Time.deltaTime * (rate*0.7f));

                if (heartBeatImage.transform.localScale == minSize)
                {
                    increasingSize = true;
                }
            }    
        }
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
