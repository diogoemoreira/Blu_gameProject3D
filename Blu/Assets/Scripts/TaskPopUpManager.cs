using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskPopUpManager : MonoBehaviour
{
    public static TaskPopUpManager instance;
    private TextMeshProUGUI text;

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

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        text.enabled = false;
    }

    public void DisplayTask(string task)
    {
        text.text = task;
        text.enabled = true;
        StartCoroutine(StopTaskDipslay());
    }

    IEnumerator StopTaskDipslay()
    {
        yield return new WaitForSeconds(5);
        text.enabled = false;
    }
}
