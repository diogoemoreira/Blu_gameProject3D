using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSwitchDoorAnimation : MonoBehaviour
{
    public bool animationDone;

    private void Start()
    {
        animationDone = false;
    }

    public void AnimDone()
    {
        animationDone = true;
    }
}
