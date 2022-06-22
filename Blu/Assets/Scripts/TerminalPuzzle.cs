using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TerminalPuzzle : InteractableUseItem
{
    public GameObject player;
    public GameObject terminalPrefab;

    public GameObject front;

    public GameObject[] screws = new GameObject[4];

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

    private Dictionary<string, GameObject> screw_Dict = new Dictionary<string, GameObject>();
    private int screwsRemoved = 0;

    public int[] cableOrder;
    private int[] currentCableOrder = new int[3];
    private int cablesRemoved = 0;
    private Dictionary<string, int> cable_Dict = new Dictionary<string, int>();


    public int[] termCode = new int[6];
    public int[] currentCodeOrder = new int[6]{0,0,0,0,0,0};
    private float dialRotation;
    private Dictionary<string, int> code_Dict = new Dictionary<string, int>();
    private int currentDial = 1;

    public static TerminalPuzzle instance;

    void Awake() {
        if (instance != null){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    private bool checkState = false;
    private bool canSolvePuzzle = false;
    private void HandleGameStateChange(GameBaseState state)
    {
        checkState = false;
        if (state == GameStateManager.instance.CheckMainDoorState)
        {
            this.neeedItem = false;
            this.StartInteraction();
            checkState = true;
        } else if (state == GameStateManager.instance.PowerOutState)
        {
            canSolvePuzzle = true;
            this.neeedItem = true;
            this.StartInteraction();
        }
        else
        {
            this.StopInteraction();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        cableOrder = new int[3]{0,1,2};
        dialRotation = 360/10f;

        System.Random rnd = new System.Random();
        cableOrder = cableOrder.OrderBy(x => rnd.Next()).ToArray();

        /*for(int i=0; i<6; i++){
            termCode[i] = (int)Mathf.Floor(Random.Range(0,10));
        }*/
        termCode = new int[] { 0, 1, 3, 6, 1, 0 };

        screw_Dict.Add("1", screws[0]);
        screw_Dict.Add("2", screws[1]);
        screw_Dict.Add("3", screws[2]);
        screw_Dict.Add("4", screws[3]);        

        cable_Dict.Add("Cabo.001", 0);
        cable_Dict.Add("Cabo.002", 1);
        cable_Dict.Add("Cabo.003", 2);

        code_Dict.Add("Lock01",0);
        code_Dict.Add("Lock02",1);
        code_Dict.Add("Lock03",2);
        code_Dict.Add("Lock04",3);
        code_Dict.Add("Lock05",4);
        code_Dict.Add("Lock06",5);

        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
        
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
                            if (hit.transform.tag == "Screws" ){
                                target = hit.collider.gameObject;

                                screwsRemoved++;
                                target.SetActive(false);
                            }
                        }

                        endPhase1();
                        
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
                                cablesRemoved++;
                                target.SetActive(false);
                            }
                        }

                        endPhase2();

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
                                
                                goRot.Rotate(0, dialRotation, 0);
                                //
                                if(currentCodeOrder[code_Dict[target.name]]>=9)
                                    currentCodeOrder[code_Dict[target.name]]=0;
                                else
                                    currentCodeOrder[code_Dict[target.name]]++;
                            }
                        }

                        endPhase3();
                        
                        break;
                }
            }
        
        }
    }

    protected override void Execute(){ 
        if(terminal!=null){return;}

        if (checkState)
        {
            SubtitlesManager.instance.DisplaySubtitles("The door is locked...My brother had the key card.");
            GameStateManager.instance.SwitchState(GameStateManager.instance.DoorManualState);
            return;
        }
        if (canSolvePuzzle)
        {
            InteractionManager.instance.InteractionPaused(true);
            //terminal = Instantiate(terminalPrefab, playerCamera.transform.position + playerCamera.transform.forward * 0.5f, playerCamera.transform.rotation);
            player.transform.position = new Vector3(-5.5f, 0.83f,59f);

            CameraLockData.setLock(false);

            playerCamera.GetComponent<MouseLook>().enabled = false;
            playerCamera.transform.parent.GetComponent<CharacterController>().enabled = false;

            interacting = true;
            if(PhysicalPuzzleManager.instance !=null)
                PhysicalPuzzleManager.instance.InitPuzzle();
        }
    }

    private void endPhase1(){
        if(screwsRemoved==4){
            //go to next phase
            front.SetActive(false);
            phase=1;
            if(PhysicalPuzzleManager.instance !=null)
                PhysicalPuzzleManager.instance.SetPhase(2);
        }
    }

    private void endPhase2(){
        if(cablesRemoved==3){
            if(currentCableOrder.SequenceEqual(cableOrder)){
                //go to next phase
                phase=-1;
                if(PhysicalPuzzleManager.instance !=null)
                    PhysicalPuzzleManager.instance.SetPhase(3);
            }
            else{
                foreach(GameObject cable in cables){
                    cable.SetActive(true);
                    cablesRemoved=0;
                }
            }
        }
    }

    private void endPhase3(){
        if(currentCodeOrder.SequenceEqual(termCode)){
            //all phases complete
            phase=2;
            Debug.Log("Puzzle Complete");
            if(PhysicalPuzzleManager.instance !=null)
                PhysicalPuzzleManager.instance.PuzzleEnd();
        }
        else if(currentDial>6){
            foreach(GameObject dial in lock_nums){                                
                dial.transform.Rotate(0, 0, 0);
            }
            currentDial=1;
        }
    }

    //static methods
    public void removeScrew(string screwNum){
        target = screw_Dict[screwNum];

        screwsRemoved++;
        target.SetActive(false);
        
        endPhase1();
    }

    public void removeCable(string cableNum){
        string name = "Cabo.00"+cableNum;

        foreach(GameObject cable in cables){
            if(cable.name == name){
                target = cable;
                break;
            }
        }

        //confirm which cable was removed
        currentCableOrder[cablesRemoved]= cable_Dict[name];
        //
        cablesRemoved++;
        target.SetActive(false);

        endPhase2();
    }

    private int lastInput = -1;

    public void combNewNum(int val)
    {
       
        //val = (int)Mathf.Floor(val / 102.4f);
        int _dialRotation = 0;

        if (val < 5)
        {
            //1
            _dialRotation = 144 +36;
            val = 1;
        }
        else if (val <= 80)
        {
            //2
            _dialRotation = 108 + 36;
            val = 2;
        }
        else if (val <= 216)
        {
            //3
            _dialRotation = 72 + 36;
            val = 3;
        }
        else if (val <= 350)
        {
            //4
            _dialRotation = 36 + 36;
            val = 4;
        }
        else if (val <= 466)
        {
            //5
            _dialRotation = 0 + 36;
            val = 5;
        }
        else if (val <= 590)
        {
            //6
            _dialRotation = -36 + 36;
            val = 6;
        }
        else if (val <= 712)
        {
            //7
            _dialRotation = -72 + 36;
            val = 7;
        }
        else if (val <= 870)
        {
            //8
            _dialRotation = -108 + 36;
            val = 8;
        }
        else if (val <= 1000)
        {
            //9
            _dialRotation = -144 + 36;
            val = 9;
        }
        else if (val <= 1024)
        {
            //0
            _dialRotation = 180 + 36;
            val = 0;
        }
        
        if (lastInput == val) { return; }
        lastInput = val;

        Debug.Log("Final: " + val);
        string name = "Lock0" + currentDial;

        foreach (GameObject dial in lock_nums)
        {
            if (dial.name == name)
            {
                target = dial;
                break;
            }
        }

        //rotate the dial
        Transform goRot = target.gameObject.transform;

        goRot.Rotate(0, _dialRotation, 0);
        //
        currentCodeOrder[code_Dict[target.name]] = val;

        currentDial++;

        endPhase3();
    }
}
