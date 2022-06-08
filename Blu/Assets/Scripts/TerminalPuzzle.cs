using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TerminalPuzzle : InteractableUseItem
{
    
    public GameObject terminalPrefab;

    public GameObject front;
    public GameObject[] cables = new GameObject[3];
    public GameObject[] lock_nums = new GameObject[6];
    private Camera playerCamera;

    //define phases
    // 0 is the first phase
    // 1 is the second phase
    // -1 is the final phase
    private int phase=0;
    private bool interacting=false;

    private Ray ray;
    private RaycastHit hit;

    private GameObject terminal=null;

    private GameObject target;

    public int[] cableOrder;
    private int[] currentCableOrder = new int[3];
    private int cablesRemoved = 0;
    private Dictionary<string, int> cable_Dict = new Dictionary<string, int>();


    public int[] termCode = new int[6];
    private int[] currentCodeOrder = new int[6]{0,0,0,0,0,0};
    private float dialRotation;
    private Dictionary<string, int> code_Dict = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        cableOrder = new int[3]{0,1,2};
        dialRotation = 360/11f;

        System.Random rnd = new System.Random();
        cableOrder = cableOrder.OrderBy(x => rnd.Next()).ToArray();
        
        for(int i=0; i<6; i++){
            termCode[i] = (int)Mathf.Floor(Random.Range(0,10));
        }

        cable_Dict.Add("Cabo.001", 0);
        cable_Dict.Add("Cabo.002", 1);
        cable_Dict.Add("Cabo.003", 2);

        code_Dict.Add("Lock01",0);
        code_Dict.Add("Lock02",1);
        code_Dict.Add("Lock03",2);
        code_Dict.Add("Lock04",3);
        code_Dict.Add("Lock05",4);
        code_Dict.Add("Lock06",5);
    }

    // Update is called once per frame
    void Update()
    {
        //need to interact with object first
        //then start phases
        if (interacting && Input.GetButtonDown("Cancel"))
            {
                Destroy(terminal);
                terminal = null;
                interacting=false;

                playerCamera.GetComponent<MouseLook>().enabled = true;
                playerCamera.transform.parent.GetComponent<CharacterController>().enabled = true;
                InteractionManager.instance.StopDisplayInteractText(this.gameObject);
                InteractionManager.instance.InteractionPaused(false);

                //unlock interfaces
                CameraLockData.setLock(true);
                UIManager.instance.UnlockInterfaces();
            }
        else if (Input.GetMouseButtonDown(0)){
            if(interacting){
                switch(phase){
                    case 0:
                        // 0 is the first phase
                        Debug.Log("PHASE 1");
                        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit)) {
                            if (hit.transform.name == "Terminall_Front" ){
                                target = hit.collider.gameObject;

                                target.SetActive(false);

                                phase=1;
                            }
                        }
                        
                        break;
                    case 1:
                        // 1 is the second phase
                        Debug.Log("PHASE 2");
                        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit)) {
                            if (hit.transform.tag == "Cables" ){
                                target = hit.collider.gameObject;

                                //confirm which cable was removed
                                currentCableOrder[cablesRemoved]= cable_Dict[target.name];
                                //
                                target.SetActive(false);
                                cablesRemoved++;
                            }
                        }

                        if(cablesRemoved==3){
                            if(currentCableOrder.SequenceEqual(cableOrder)){
                                phase=-1;
                            }
                            else{
                                foreach(GameObject cable in cables){
                                    cable.SetActive(true);
                                    cablesRemoved=0;
                                }
                            }
                        }

                        break;
                    case -1:
                        // -1 is the final phase
                        Debug.Log("PHASE 3");
                        this.ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        if (Physics.Raycast(ray, out hit)) {
                            if (hit.transform.tag == "Dials" ){
                                target = hit.collider.gameObject;

                                //rotate the dial
                                Transform goRot = target.gameObject.transform;
                                
                                goRot.Rotate(0, 0, dialRotation);
                                Debug.Log("rot: " + goRot.rotation.z);
                                //
                                currentCodeOrder[code_Dict[target.name]] = (int) Mathf.Floor(goRot.rotation.z/dialRotation);
                            }
                        }

                        if(currentCableOrder.SequenceEqual(termCode)){
                            //all phases complete
                            phase=2;
                            Debug.Log("Puzzle Complete");
                        }
                        
                        break;
                }
            }
        
        }
    }

    protected override void Execute(){ 
        if(terminal!=null){return;}

        InteractionManager.instance.InteractionPaused(true);
        //terminal = Instantiate(terminalPrefab, playerCamera.transform.position + playerCamera.transform.forward * 0.5f, playerCamera.transform.rotation);
        terminal = Instantiate(terminalPrefab, playerCamera.transform.forward * 0.5f, Quaternion.identity );
        
        CameraLockData.setLock(false);

        playerCamera.GetComponent<MouseLook>().enabled = false;
        playerCamera.transform.parent.GetComponent<CharacterController>().enabled = false;

        interacting = true;
    }
}
