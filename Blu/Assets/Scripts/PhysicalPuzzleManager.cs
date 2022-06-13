using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PhysicalPuzzleManager : MonoBehaviour
{
    SerialPort ard;
    public string com = "COM2";
    public int baudrate = 9600;

    public static PhysicalPuzzleManager instance;

    void Awake() {
        if (instance != null){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    void Start()
    {
        ard = new SerialPort(com, baudrate);
        ard.Open();
        ard.ReadTimeout = 16;
    }

    // Update is called once per frame
    void Update()
    {
        if (ard.IsOpen)
        {
            try
            {
                string message = ard.ReadLine();
                string[] args = message.Split(",");

                if (args[0] == "parafusoRetirado"){
                    
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public void Close()
    {
        ard.Close();
    }

    public void InitPuzzle(){
        if (ard.IsOpen)
        {
            try
            {
                ard.Write("init");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public void SetPhase(int phase) {
        if (ard.IsOpen)
        {
            try
            {
                ard.Write("phase"+phase);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    public void PuzzleEnd(){
        if (ard.IsOpen)
        {
            try
            {
                ard.Write("end");
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
