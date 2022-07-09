using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalManualInteraction : InteractableUseItem
{
    public Sprite manualSprite;
    public TextMeshPro manual_text;

    public string m_text;
    
    private string[] colors = new string[]{"Yellow","Red","Blue"};

    private void Start() {
        int[] c =TerminalPuzzle.instance.GetCableOrder();
        string cables = colors[c[0]]+", "+colors[c[1]]+", "+colors[c[2]];
        m_text="Analogic system:\n- Turn off power\n- Open door terminal\n(remove screws)\n- Remove Wires:\n"+cables+"\n- Insert 6 digit code\n(default code is 000000)";
        manual_text.SetText(m_text);
    }

    protected override void Execute()
    {
        ReadPaper.instance.ShowPaper(m_text);
        if (GameStateManager.instance.currentState == GameStateManager.instance.DoorManualState)
        {
            GameStateManager.instance.SwitchState(GameStateManager.instance.TurnOffPowerState);
        }
    }
}
