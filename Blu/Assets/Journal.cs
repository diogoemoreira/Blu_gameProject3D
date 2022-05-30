using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public static Journal instance;
    public Sprite[] pages;

    public Image leftPage;
    public Image rightPage;
    public GameObject journal;
    public GameObject leftButton;
    public GameObject rightButton;

    private List<int> unlockedPages;
    private int currentLastPage = 0;
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
        leftPage.enabled = false;
        rightPage.enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        journal.SetActive(false);
    }

    public void AddPage(Texture tex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].name == tex.name)
            {
                unlockedPages.Add(i);
                ProcessPages();
                break;
            }
        }
    }

    private void ProcessPages()
    {
        unlockedPages.Sort();
        if (unlockedPages.Count > 0)
        { 
            leftPage.sprite = pages[unlockedPages[0]];
            currentLastPage = 0;
            leftPage.GetComponent<Image>().enabled = true;

            if (unlockedPages.Count > 1)
            {
                rightPage.sprite = pages[unlockedPages[1]];
                currentLastPage = 1;
                rightPage.GetComponent<Image>().enabled = true;

                if (unlockedPages.Count > 2)
                {
                    rightButton.SetActive(true);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Journal") && !UIManager.instance.IsPaused())
        {
            CameraLockData.setLock(journal.activeInHierarchy);
            Time.timeScale = Convert.ToInt32(journal.activeInHierarchy);
            journal.SetActive(!journal.activeInHierarchy);
            Data.setPaused(journal.activeInHierarchy);
        }
    }

    public void NextRight()
    {
        if (unlockedPages.Count > currentLastPage + 1)
        {
            currentLastPage++;
            leftPage.sprite = pages[unlockedPages[currentLastPage]];

            if (unlockedPages.Count > currentLastPage+2)
            {
                rightButton.SetActive(true);
            } else
            {
                rightButton.SetActive(false);
            }

            currentLastPage++;
            if (unlockedPages.Count > currentLastPage)
            {
                rightPage.enabled = true;
                rightPage.sprite = pages[unlockedPages[currentLastPage]];
            } else
            {
                rightPage.enabled = false;
            }

            leftButton.SetActive(true);
        }
    }
    public void NextLeft()
    {
        if (currentLastPage - 3 >= 0)
        {
            currentLastPage -= 3;
            leftPage.sprite = pages[unlockedPages[currentLastPage]];

            if (currentLastPage > 1)
            {
                leftButton.SetActive(true);
            }
            else
            {
                leftButton.SetActive(false);
            }

            currentLastPage++;
            if (unlockedPages.Count > currentLastPage)
            {
                rightPage.enabled = true;
                rightPage.sprite = pages[unlockedPages[currentLastPage]];
            }
            else
            {
                rightPage.enabled = false;
            }

            rightButton.SetActive(true);
        }
    }
}
