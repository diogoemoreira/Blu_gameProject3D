using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableUseItem
{
    public Transform anchorPoint;
    protected override void Execute()
    {
        this.StopInteraction();
        this.transform.RotateAround(anchorPoint.position, new Vector3(0.0f, 1.0f, 0.0f), -90);  
    }
}
