using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPuzzle : MonoBehaviour
{
    GameObject front;
    GameObject[] cables = new GameObject[3];
    GameObject[] lock_nums = new GameObject[6];

    //define phases
    // 0 is the first phase
    // 1 is the second phase
    // -1 is the final phase
    private int phase=0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //need to interact with object first
        //then start phases
        switch(phase){
            case 0:
            // 0 is the first phase
                /*
                if (Input.GetMouseButtonDown(0)) {
                    RaycastHit hit;
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.transform.name == "Terminall_Front" )Debug.Log( "My object is clicked by mouse");
                    }
                }
                */
                break;
            case 1:
            // 1 is the second phase
                break;
            case -1:
            // -1 is the final phase
                break;
        }
    }
}
