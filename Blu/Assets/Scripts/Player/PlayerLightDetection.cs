using UnityEngine;

public class PlayerLightDetection : MonoBehaviour
{
    public float lightDetected = 0f;
    public float detectionRange = 20f;
    
    private int mask = 1<<9;
    private GameObject[] plights;
    private bool canDetect = false;

    // Start is called before the first frame update
    void Start()
    {
        plights = GameObject.FindGameObjectsWithTag("Light");
        mask = ~mask;
        GameStateManager.instance.GSChangeEvent.AddListener(HandleGameStateChange);
    }

    private void HandleGameStateChange(GameBaseState state)
    {
        if (state == GameStateManager.instance.PowerOutState)
        {
            canDetect = true;
        }
        else
        {
            canDetect = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canDetect) { return; }
        //another option is using triggers and calling events
        lightDetected = 0f;
        foreach(GameObject plight in plights){
            if(plight.GetComponent<Light>().enabled && !Physics.Linecast(transform.position, plight.transform.position, mask)){
                //get the distance from the light
                float distance = Vector3.Distance(transform.position, plight.transform.position);
                if(distance<detectionRange){
                    float lightIntensity = plight.GetComponent<Light>().intensity; //in range light intensity
                    lightDetected += (1/distance) * (lightIntensity * 10);
                }
            }
        }
        if(lightDetected<0.4f && Flashlight.instance.getFlashlightStatus()){
            lightDetected = 0.4f;
        }
        HeartRateManager.instance.LightLevel(lightDetected);
    }
}
