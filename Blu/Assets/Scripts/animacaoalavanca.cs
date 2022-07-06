using UnityEngine;

public class animacaoalavanca : InteractableUseItem{

    private string[] anims = new string[]{"movealavanca","botoesmexer", "2movebuttons"};
    private int curr_anim=0;

    protected override void Execute()
    {
        this.StopInteraction();
        this.gameObject.GetComponent<Animator>().Play(anims[curr_anim]);
        curr_anim++;
    }

    public void AnimationOver()
    {
        this.StartInteraction();
    }
}
