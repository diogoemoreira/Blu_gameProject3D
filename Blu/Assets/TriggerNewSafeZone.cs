using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewSafeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SafeZoneManager.instance.SetSafeZone(this.transform.position);
    }
}
