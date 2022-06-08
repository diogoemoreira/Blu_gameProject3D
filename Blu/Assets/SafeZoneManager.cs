using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneManager : MonoBehaviour
{
    public static SafeZoneManager instance;

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

    private Vector3 lastSafeZone;

    public void SetSafeZone(Vector3 pos)
    {
        lastSafeZone = pos;
    }

    public Vector3 GetLastSafeZone()
    {
        return lastSafeZone;
    }
}
