using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalManualInteraction : InteractableUseItem
{
    public Sprite manualSprite;
    public TextMeshPro manual_text;
    
    private string[] colors = new string[]{"Yellow","Red","Blue"};

    private void Start() {
        int[] c =TerminalPuzzle.instance.GetCableOrder();
        string cables = colors[c[0]]+", "+colors[c[1]]+", "+colors[c[2]];
        manual_text.text = "Analogic system:\n- Turn off power\n- Open door terminal\n(remove screws)\n- Remove Wires "+cables+"\n- Insert 6 digit code\n(default code is 000000)";
    }

    protected override void Execute()
    {
        ReadPaper.instance.ShowPaper(manualSprite);
        if (GameStateManager.instance.currentState == GameStateManager.instance.DoorManualState)
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.TurnOffPowerState);
        }
    }
}
