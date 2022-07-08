using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageInteraction : InteractableUseItem
{
    private Camera playerCamera;
    public GameObject pagePrefab;
    private GameObject pagina;
    public Material material;
    private bool skipFrame;
    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.gameObject.GetComponent<MeshRenderer>().material = material;
        skipFrame = false;
    }

    private void Update()
    {
        if (pagina != null && !skipFrame)
        {
            if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Interact"))
            {
                Destroy(pagina);
                pagina = null;
                playerCamera.GetComponent<MouseLook>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
                InteractionManager.instance.StopDisplayInteractText(this.gameObject);
                InteractionManager.instance.InteractionPaused(false);

                //unlock interfaces
                UIManager.instance.UnlockInterfaces();

                Journal.instance.AddPage(this.GetComponent<MeshRenderer>().material.mainTexture);
                Destroy(this.gameObject);
            }
        }
        skipFrame = false;
    }

    protected override void Execute()
    {
        if (pagina != null) { return; }

        skipFrame = true;
        //lock interfaces
        UIManager.instance.LockInterfaces();

        InteractionManager.instance.InteractionPaused(true);
        pagina = Instantiate(pagePrefab, (playerCamera.transform.position + playerCamera.transform.forward * 0.6f) + new Vector3(0.0f,0.45f,0.0f), playerCamera.transform.rotation);
        pagina.transform.Rotate(135,180,0);
        pagina.GetComponent<MeshRenderer>().material = material;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
    }
}
