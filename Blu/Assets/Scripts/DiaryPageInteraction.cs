using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageInteraction : InteractableUseItem
{
    private Camera playerCamera;
    public GameObject pagePrefab;
    private GameObject pagina;
    public Material material;
    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.gameObject.GetComponent<MeshRenderer>().material = material;
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
                playerCamera.transform.parent.GetComponent<CharacterController>().enabled = true;
                InteractionManager.instance.StopDisplayInteractText(this.gameObject);
                InteractionManager.instance.InteractionPaused(false);

                //unlock interfaces
                UIManager.instance.UnlockInterfaces();

                Journal.instance.AddPage(this.GetComponent<MeshRenderer>().material.mainTexture);
                Destroy(this.gameObject);
            }
        }
    }

    protected override void Execute()
    {
        if (pagina != null) { return; }

        //lock interfaces
        UIManager.instance.LockInterfaces();

        InteractionManager.instance.InteractionPaused(true);
        pagina = Instantiate(pagePrefab, playerCamera.transform.position + playerCamera.transform.forward * 0.5f, playerCamera.transform.rotation);
        pagina.transform.Rotate(90,180,0);
        pagina.GetComponent<MeshRenderer>().material = material;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        playerCamera.transform.parent.GetComponent<CharacterController>().enabled = false;
    }
}
