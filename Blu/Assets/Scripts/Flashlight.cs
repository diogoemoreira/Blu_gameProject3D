using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool drainOverTime = true;
    public float maxBrightness = 1f;
    public float minBrightness = 0.2f;
    public float drainRate = 2;
    public float noBatteries=0;
    Light m_light;

    bool usable = false;

    public static Flashlight instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
        m_light.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(usable){
            if(drainOverTime && m_light.enabled){
                
                if(m_light.intensity > minBrightness){
                    ChangeLightIntensity(m_light.intensity - Time.deltaTime *(drainRate/1000));
                }
            }

            if(Input.GetKeyDown(KeyCode.F)){
                changeFlashlightStatus();
            }

            if(Input.GetKeyDown(KeyCode.R) && noBatteries>0){
                ReplaceBattery();
            }
            if(m_light.intensity<=minBrightness+0.1f){
                changeFlashlightStatus(false);
            }
        }
        
        
    }

    public void ReplaceBattery(){
        m_light.intensity= maxBrightness;
        noBatteries-=1;
    }

    public void changeFlashlightStatus(){
        //changes enabled status from flashlight
        m_light.enabled = !m_light.enabled;
    }

    public void changeFlashlightStatus(bool status){
        //changes enabled status from flashlight
        m_light.enabled = status;
    }

    public void ChangeLightIntensity(float newLightIntensity){
        //used to change the intensity of the flash light
        m_light.intensity = newLightIntensity;

        m_light.intensity = Mathf.Clamp(m_light.intensity, minBrightness, maxBrightness);
    }

    public bool getFlashlightStatus(){
        return m_light.enabled;
    }

    public void AddBattery()
    {
        noBatteries += 1;
    }

    public void flashUsable(){
        usable=true;
    }
}
