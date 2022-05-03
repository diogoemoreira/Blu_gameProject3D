using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool drainOverTime = true;
    public float maxBrightness = 1f;
    public float minBrightness = 0.2f;
    public float drainRate = 2;
    Light m_light;
    float noBatteries=1;

    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drainOverTime && m_light.enabled){
            
            if(m_light.intensity > minBrightness){
                ChangeLightIntensity(m_light.intensity - Time.deltaTime *(drainRate/1000));
            }
        }

        if(Input.GetKeyDown(KeyCode.F)){
            m_light.enabled = !m_light.enabled;
        }

        if(Input.GetKeyDown(KeyCode.R) && noBatteries>0){
            ReplaceBattery();
        }
        
    }

    public void ReplaceBattery(){
        m_light.intensity= maxBrightness;
        noBatteries-=1;
    }

    public void ChangeLightIntensity(float newLightIntensity){
        //used to change the intensity of the flash light
        m_light.intensity = newLightIntensity;

        m_light.intensity = Mathf.Clamp(m_light.intensity, minBrightness, maxBrightness);
    }
}
