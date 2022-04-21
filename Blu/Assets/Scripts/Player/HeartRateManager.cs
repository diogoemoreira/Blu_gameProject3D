using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateManager : MonoBehaviour
{
    public int currentHeartRate;
    public int minHeartRate;
    public int maxHeartRate;
    private int multiplier;

    private float hearRateUpdate = 0.5f;
    private float lastUpdate = 0f;

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
    }

    private void UpdateUI()
    {

    }

    public void Jump()
    {
        multiplier = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastUpdate + hearRateUpdate)
        {
            currentHeartRate += Random.Range(-3 + multiplier, 3 + multiplier);

            if (currentHeartRate < minHeartRate)
            {
                currentHeartRate = minHeartRate;
            }

            if (currentHeartRate > minHeartRate + 30)
            {
                currentHeartRate = minHeartRate + 30;
            }

            if (currentHeartRate > maxHeartRate)
            {
                // FAINT
            }

            UpdateUI();
            multiplier = 0;
            lastUpdate = Time.time;
        }
    }
}
