using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeechItem : InteractableItem
{
    public string speech;

    protected override void TriggerInteraction()
    {
        Debug.Log(speech);
    }
}
