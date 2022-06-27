using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePageInteraction : InteractableUseItem
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
                playerCamera.transform.parent.GetComponent<CharacterController>().enabled = true;
                InteractionManager.instance.StopDisplayInteractText(this.gameObject);
                InteractionManager.instance.InteractionPaused(false);

                //unlock interfaces
                UIManager.instance.UnlockInterfaces();

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
        pagina.transform.Rotate(0,30,-30);
        pagina.GetComponentInChildren<TextMeshPro>().text = "123456";
        playerCamera.GetComponent<MouseLook>().enabled = false;
        playerCamera.transform.parent.GetComponent<CharacterController>().enabled = false;
    }
}
