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
        try{
            ard = new SerialPort(com, baudrate);
            ard.Open();
            ard.ReadTimeout = 16;
        }catch(System.Exception){throw;}
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
                    TerminalPuzzle.instance.removeScrew(args[1]);
                }
                 else if (args[0] == "cableRemoved"){
                    TerminalPuzzle.instance.removeCable(args[1]);
                } else
                {
                    try
                    {
                        int val = int.Parse(args[0]);
                        //Debug.Log(args[0]);
                        TerminalPuzzle.instance.combNewNum(val);
                    } catch (System.Exception) { throw; }
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
