using UnityEngine;

public class PlayerLightDetection : MonoBehaviour
{
    public float lightDetected = 0.000001f;
    public float detectionRange = 20f;
    
    private int mask = 1<<9;
    private GameObject[] plights;

    // Start is called before the first frame update
    void Start()
    {
        plights = GameObject.FindGameObjectsWithTag("Light");
        mask = ~mask;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //another option is using triggers and calling events
        lightDetected = 0.0000001f;
        foreach(GameObject plight in plights){
            if(!Physics.Linecast(transform.position, plight.transform.position, mask)){
                //get the distance from the light
                float distance = Vector3.Distance(transform.position, plight.transform.position);

                if(distance<detectionRange){
                    float lightIntensity = plight.GetComponent<Light>().intensity; //in range light intensity
                    lightDetected += (1/distance) * lightIntensity;
                }
            }
        }
        HeartRateManager.instance.LightLevel(lightDetected);
    }
}
