using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageInteraction : InteractableUseItem
{
    private Camera playerCamera;
    public GameObject pagePrefab;
    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
    }
    protected override void Execute()
    {
        InteractionManager.instance.StopDisplayInteractText(this.gameObject);
        GameObject page = Instantiate(pagePrefab, playerCamera.transform.position + playerCamera.transform.forward * 0.5f, playerCamera.transform.rotation);
        page.transform.Rotate(-90,0,0);
    }
}
