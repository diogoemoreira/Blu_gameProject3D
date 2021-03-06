using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance {get; private set; }
    public GameObject InteractionTextPrefab;

    private GameObject player;

    private GameObject currentInteractionText;
    private GameObject currentOrigin; 
    private List<GameObject> activeInteractableObjects;

    private bool interactionPaused;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activeInteractableObjects = new List<GameObject>();
    }

    private void Update()
    {
        if (interactionPaused) {
            Destroy(currentInteractionText);
            currentInteractionText = null;
            currentOrigin = null;
            return; 
        }

        GameObject closest = null;
        float closestDist = 0.0f;
        for (int i = 0; i < activeInteractableObjects.Count; i++)
        {
            if (closest == null)
            {
                closest = activeInteractableObjects[i];
                closestDist = Vector3.Distance(player.transform.position, closest.transform.position);
            }
            else if (closestDist > Vector3.Distance(player.transform.position, activeInteractableObjects[i].transform.position))
            {
                closest = activeInteractableObjects[i];
                closestDist = Vector3.Distance(player.transform.position, closest.transform.position);
            }
        }

        if (closest != null)
        {
            if (currentOrigin != closest)
            {
                Destroy(currentInteractionText);
                currentInteractionText = Instantiate(InteractionTextPrefab, closest.transform.position, new Quaternion(0f, 0f, 0f, 0f));
                currentOrigin = closest;
            }

            if (Input.GetButton("Interact") && !UIManager.instance.IsPaused())
            {
                currentOrigin.GetComponent<InteractableItem>().Interact();
            }
        }
        else if (currentInteractionText != null)
        {
            Destroy(currentInteractionText);
            currentInteractionText = null;
            currentOrigin = null;
        }
    }

    public void DisplayInteractionText(GameObject origin)
    {
        if (activeInteractableObjects != null && !activeInteractableObjects.Contains(origin))
        {
            activeInteractableObjects.Add(origin);
        }
    }

    public void StopDisplayInteractText(GameObject origin)
    {
        if (activeInteractableObjects != null)
        {
            activeInteractableObjects.Remove(origin);
        }
    }

    public void InteractionPaused(bool paused)
    {
        interactionPaused = paused;
    }
}
