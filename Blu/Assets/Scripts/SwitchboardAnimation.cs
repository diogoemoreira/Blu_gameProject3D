using UnityEngine;

public class SwitchboardAnimation : InteractableUseItem{

    private bool opened = false;
    private Animator switchAnim;
    public GameObject flashlight;
    public Animator switchAnimator;
    private bool checkAnimationDone;
    private void Start() {
        switchAnim = this.gameObject.GetComponentInChildren<Animator>();
        checkAnimationDone = false;
    }

    protected override void Execute()
    {
        this.StopInteraction();
        if (!opened)
        {
            switchAnim.Play("EletricalSwitchOpening");
            opened = true;
            checkAnimationDone = true;
        } else
        {
            switchAnimator.Play("Switch_TurningOff");
            GameStateManager.instance.SwitchState(GameStateManager.instance.PowerOutState);
            Destroy(flashlight);
        }
    }

    private void Update()
    {
        if (checkAnimationDone && this.GetComponentInChildren<WaitForSwitchDoorAnimation>().animationDone)
        {
            this.StartInteraction();
            checkAnimationDone = false;
        }
    }
}
