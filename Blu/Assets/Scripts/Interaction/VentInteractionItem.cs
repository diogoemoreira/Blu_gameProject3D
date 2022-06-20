using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentInteractionItem : InteractableUseItem
{
    protected override void Execute()
    {
        this.gameObject.GetComponent<Animator>().Play("OpenVent");
    }
}
