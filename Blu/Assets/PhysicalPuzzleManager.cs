using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PhysicalPuzzleManager : MonoBehaviour
{
    SerialPort ard;
    public string com = "COM2";
    public int baudrate = 9600;

    void Start()
    {
        ard = new SerialPort(com, baudrate);
        ard.Open();
        ard.ReadTimeout = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (ard.IsOpen)
        {
            try
            {
                print(ard.ReadLine());
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
}
