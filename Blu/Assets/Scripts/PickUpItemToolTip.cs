using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItemToolTip : MonoBehaviour
{
    public static PickUpItemToolTip instance;
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

    public GameObject content;
    private Text texto;
    void Start()
    {
        content.SetActive(false);
        texto = content.gameObject.GetComponentInChildren<Text>();
    }

    public void ShowToolTip(string name)
    {
        texto.text = "+1 " + name;
        content.SetActive(true);
        StartCoroutine(TimerToHide());
    }

    IEnumerator TimerToHide()
    {
        yield return new WaitForSeconds(2f);
        content.SetActive(false);
    }
}
