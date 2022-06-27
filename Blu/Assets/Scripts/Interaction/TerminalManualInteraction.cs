using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalManualInteraction : InteractableUseItem
{
    public Sprite manualSprite;

    protected override void Execute()
    {
        ReadPaper.instance.ShowPaper(manualSprite);
    }
}
