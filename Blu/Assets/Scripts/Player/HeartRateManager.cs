using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void UpdateUI()
    {

    }

    public void Jump()
    {
        multiplier = 5;
    }

    public void Sprint()
    {
        multiplier = 5;
        sprinting = true;
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
            if (currentHeartRate > minHeartRate + 30 && !sprinting)
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
                currentHeartRate = maxHeartRate;
            }

            HeartBeatUI.instance.UpdateHeartBeat(currentHeartRate);
            UpdateUI();
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
