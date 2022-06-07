using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubtitlesManager : MonoBehaviour
{
    public static SubtitlesManager instance;

    private TextMeshProUGUI textComponent;

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
        textComponent = this.GetComponent<TextMeshProUGUI>();
        textComponent.enabled = false;
    }

    public void DisplaySubtitles(string text)
    {
        textComponent.text = text;
        textComponent.enabled = true;
        StartCoroutine(CountDownSubtitles());
    }

    IEnumerator CountDownSubtitles()
    {
        yield return new WaitForSeconds(2);
        textComponent.enabled = false;
    }
}
