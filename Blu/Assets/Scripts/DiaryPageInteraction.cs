using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageInteraction : InteractableUseItem
{
    private Camera playerCamera;
    public GameObject pagePrefab;
    private GameObject pagina;
    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
    }

    private void Update()
    {
        if (pagina != null)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Destroy(pagina);
                pagina = null;
                playerCamera.GetComponent<MouseLook>().enabled = true;
                InteractionManager.instance.DisplayInteractionText(this.gameObject);
            }
        }
    }

    protected override void Execute()
    {
        if (pagina != null) { return; }
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
        pagina = Instantiate(pagePrefab, playerCamera.transform.position + playerCamera.transform.forward * 0.5f, playerCamera.transform.rotation);
        pagina.transform.Rotate(-90,0,0);
        playerCamera.GetComponent<MouseLook>().enabled = false;
    }
}
