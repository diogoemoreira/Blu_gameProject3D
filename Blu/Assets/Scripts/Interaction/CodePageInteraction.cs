using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
using System;

public class CodePageInteraction : InteractableUseItem
{
    private Camera playerCamera;
    public GameObject pagePrefab;
    private GameObject pagina;
    private string code;
    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        int[] codeOrder = TerminalPuzzle.instance.termCode;
        string[] result = codeOrder.Select(i => i.ToString()).ToArray();
        code = String.Join("", result);
        this.gameObject.GetComponentInChildren<TextMeshPro>().text = code;
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
                InteractionManager.instance.StopDisplayInteractText(this.gameObject);
                InteractionManager.instance.InteractionPaused(false);

                //unlock interfaces
                UIManager.instance.UnlockInterfaces();
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
        pagina.transform.Rotate(0,90,-90);
        pagina.GetComponentInChildren<TextMeshPro>().text = code;
        playerCamera.GetComponent<MouseLook>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
    }
}
