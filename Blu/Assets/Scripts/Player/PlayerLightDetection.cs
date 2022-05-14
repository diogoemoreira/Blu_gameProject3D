using UnityEngine;

public class PlayerLightDetection : MonoBehaviour
{
    float lightDetected = 0f;
    float detectionRange = 20f;
    
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
        lightDetected = 0f;
        foreach(GameObject plight in plights){
            if(!Physics.Linecast(transform.position, plight.transform.position, mask)){
                float distance = Vector3.Distance(transform.position, plight.transform.position);
                if(distance<detectionRange){
                    lightDetected += (1/distance);
                }
            }
        }
        HeartRateManager.instance.LightLevel(lightDetected);
    }
}
