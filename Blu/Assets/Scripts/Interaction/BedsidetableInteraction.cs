using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsidetableInteraction : InteractableUseItem
{
    private bool closed = true;
    private Animator anim;
    private void Start()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    protected override void Execute()
    {
        this.StopInteraction();
        if (closed)
        {
            anim.Play("OpenDrawer");
            closed = false;
        } else
        {
            anim.Play("CloseDrawer");
            closed = true;
        }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
