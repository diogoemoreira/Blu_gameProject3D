using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedsidetableInteraction : InteractableUseItem
{
    private bool closed = true;
    private Animator anim;

    public InteractableUseItem codePage;
    public InteractableUseItem diaryPage;
    private void Start()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
        if (codePage)
        {
            codePage.StopInteraction();
        }
        if (diaryPage)
        {
            diaryPage.StopInteraction();
        }
    }

    protected override void Execute()
    {
        this.StopInteraction();
        if (closed)
        {
            anim.Play("OpenDrawer");
            closed = false;
            
            if (diaryPage)
            {
                diaryPage.StartInteraction();
            }
            else if (codePage)
            {
                codePage.StartInteraction();
            }
        } else
        {
            anim.Play("CloseDrawer");
            closed = true;
            if (codePage)
            {
                codePage.StopInteraction();
            }
            if (diaryPage)
            {
                diaryPage.StopInteraction();
            }
        }
    }

    private void Update()
    {
        if (!closed && diaryPage == null)
        {
            codePage.StartInteraction();
        }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
