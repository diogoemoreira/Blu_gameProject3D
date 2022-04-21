using UnityEngine;

public class PlayerLightDetection : MonoBehaviour
{
    float lightDetected = 0f;
    float detectionRange = 20f;
    private GameObject[] plights;

    // Start is called before the first frame update
    void Start()
    {
        plights = GameObject.FindGameObjectsWithTag("Light");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //another option is using triggers and calling events
        lightDetected = 0f;
        foreach(GameObject plight in plights){
            float distance = Vector3.Distance(transform.position, plight.transform.position);
            Debug.Log("Distance: "+distance);
            if(distance<detectionRange){
                lightDetected += (1/distance);
            }
        }
        Debug.Log(lightDetected);
    }
}
