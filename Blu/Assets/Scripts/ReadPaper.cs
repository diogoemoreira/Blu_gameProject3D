using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPaper : MonoBehaviour
{
    public static ReadPaper instance;

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

    public GameObject screen;
    public GameObject content;
    private Camera playerCamera;
    void Start()
    {
        screen.SetActive(false);
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void ShowPaper(Sprite sprite)
    {
        UIManager.instance.LockInterfaces();
        InteractionManager.instance.InteractionPaused(true);
        content.GetComponent<Image>().sprite = sprite;
        screen.SetActive(true);
        CameraLockData.setLock(false);
        Data.setPaused(true);
        playerCamera.GetComponent<MouseLook>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
    }

    public void Close()
    {
        UIManager.instance.UnlockInterfaces();
        InteractionManager.instance.InteractionPaused(false);
        screen.SetActive(false);
        CameraLockData.setLock(true);
        Data.setPaused(false);
        playerCamera.GetComponent<MouseLook>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = true;
    }
}
