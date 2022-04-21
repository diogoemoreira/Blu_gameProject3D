using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeechItem : InteractableItem
{
    public string speech;
    public bool alreadySeen = false;

    protected override void Update()
    {
        base.Update();
    }

    protected override void TriggerInteraction()
    {
        if (!alreadySeen) {
            Debug.Log(speech);
            alreadySeen = true; 
        }
    }
}
