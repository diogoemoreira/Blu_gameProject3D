using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowOpenDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<DoorInteraction>().locked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInParent<DoorInteraction>().locked = true;
        }
    }
}
