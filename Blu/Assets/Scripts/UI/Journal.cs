using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public static Journal instance;
    public Sprite[] pagesSprites;

    public GameObject journal;
    public GameObject journalBk;
    public GameObject pageDisplay;

    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;

    private List<int> unlockedPages;

    // Tasks
    public Text tasksText;
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

    void Start()
    {
        unlockedPages = new List<int>();
        journalBk.SetActive(false);
        page1.SetActive(false);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
    }

    public void AddPage(Texture tex)
    {
        for (int i = 0; i < pagesSprites.Length; i++)
        {
            if (pagesSprites[i].name == tex.name)
            {
                unlockedPages.Add(i);
                ProcessNewPage(i);
                break;
            }
        }
    }

    private void ProcessNewPage(int page)
    {
        switch (page)
        {
            case 0:
                {
                    page1.SetActive(true);
                    break;
                }
            case 1:
                {
                    page2.SetActive(true);
                    break;
                }
            case 2:
                {
                    page3.SetActive(true);
                    break;
                }
            case 3:
                {
                    page4.SetActive(true);
                    break;
                }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Journal") && !UIManager.instance.IsPaused())
        {
            Activate();
        }
        if(Input.GetButtonDown("Cancel") && journalBk.activeInHierarchy){
            Activate();
        }
        
    }

    public void Activate(){
        CameraLockData.setLock(journalBk.activeInHierarchy);
        Time.timeScale = Convert.ToInt32(journalBk.activeInHierarchy);
        journalBk.SetActive(!journalBk.activeInHierarchy);
        Data.setPaused(journalBk.activeInHierarchy);

        if (journalBk.activeInHierarchy)
        {
            UIManager.instance.LockInterfaces();

            InteractionManager.instance.InteractionPaused(true);
        } else
        {
            InteractionManager.instance.InteractionPaused(false);

            //unlock interfaces
            UIManager.instance.UnlockInterfaces();
        }
    }

    public void DisplayPage(int page)
    {
        pageDisplay.GetComponent<Image>().sprite = pagesSprites[page];
        journal.SetActive(false);
        pageDisplay.SetActive(true);
    }

    public void ReturnToJournal()
    {
        journal.SetActive(true);
        pageDisplay.SetActive(false);
    }

    public void SetCurrentTask(string text)
    {
        tasksText.text = text;
        TaskPopUpManager.instance.DisplayTask(text);
    }
}
