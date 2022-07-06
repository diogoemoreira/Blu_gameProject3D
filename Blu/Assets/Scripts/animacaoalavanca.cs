using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacaoalavanca : MonoBehaviour

{

    void Start()

    {

    }

    void Update()

    {

    }


    public void OnMouseDown()

    {

        this.GetComponent<Animator>().Play("movealavanca");
        print("---- CLicou!");
    }

    public void OnMouseUp()

    {

        this.GetComponent<Animator>().Play("stopalavanca");

    }

}
