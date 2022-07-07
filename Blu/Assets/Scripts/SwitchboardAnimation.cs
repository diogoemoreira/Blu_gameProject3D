using UnityEngine;

public class SwitchboardAnimation : InteractableUseItem{

    private bool opened = false;
    private Animator switchAnim;

    private void Start() {
        switchAnim = this.gameObject.GetComponent<Animator>();
    }

    protected override void Execute()
    {
        this.StopInteraction();
            if (!opened)
            {
                switchAnim.Play("EletricalSwitchOpening");
                opened = true;
            }
            else
            {
                switchAnim.Play("EletricalSwitchClosing");
                opened = false;
            }
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
