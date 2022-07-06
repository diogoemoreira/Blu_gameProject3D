using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class controlanimations : MonoBehaviour

{

    void Start()

    {

    }

    void Update()

    {

    }

    public void OnMouseDown()

    {

        this.GetComponent<Animator>().Play("botoesmexer");

    }

    public void OnMouseUp()

    {

        this.GetComponent<Animator>().Play("stopbuttons");

    }

}