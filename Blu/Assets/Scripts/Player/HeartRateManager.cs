using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeartRateManager : MonoBehaviour
{
    public int currentHeartRate;
    public int minHeartRate;
    public int maxHeartRate;
    public int multiplier;
    private bool sprinting;

    private float hearRateUpdate = 0.5f;
    private float lastUpdate = 0f;
    private bool canUpdateLight = true;

    private CharacterController charController;

    public UnityEvent respawnEvent;

    public static HeartRateManager instance;
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

    void Start()
    {
        currentHeartRate = minHeartRate;
        multiplier = 0;
        charController = this.GetComponent<CharacterController>();
        respawnEvent = new UnityEvent();
    }

    public void ForceMultiplier(int mult)
    {
        multiplier = mult;
    }

    public void LightLevel(float lightLevel)
    {
        if (canUpdateLight)
        {
            multiplier += Mathf.Min((int)((1 / (lightLevel + 0.01)) * 0.3f),20);
            canUpdateLight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastUpdate + hearRateUpdate)
        {
            if (currentHeartRate > minHeartRate + 30)
            {
                multiplier -= 5;
            }

            currentHeartRate += Random.Range(-3 + multiplier, 3 + multiplier);

            if (currentHeartRate < minHeartRate)
            {
                currentHeartRate = minHeartRate;
            }
            
            if (currentHeartRate > maxHeartRate)
            {
                charController.enabled = false;
                this.transform.position = SafeZoneManager.instance.GetLastSafeZone();
                charController.enabled = true;
                currentHeartRate = minHeartRate;
                respawnEvent.Invoke();
            }

            HeartBeatUI.instance.UpdateHeartBeat(currentHeartRate);
            multiplier = 0;
            lastUpdate = Time.time;
            canUpdateLight = true;

            if (sprinting)
            {
                sprinting = false;
                multiplier = -5;
            }
        }
    }
}
