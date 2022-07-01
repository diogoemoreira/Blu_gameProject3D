using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBatteryInteraction : InteractableUseItem
{
 
    protected override void Execute()
    {
        this.StopInteraction();
        Flashlight.instance.AddBattery();
        Destroy(this.gameObject);
    }
}
