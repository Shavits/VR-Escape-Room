using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Riddle1Controller : MonoBehaviour
{

    [SerializeField] XRSocketInteractor TopLeftSocket;
    [SerializeField] XRSocketInteractor TopRightSocket;
    [SerializeField] XRSocketInteractor BottomLeftSocket;
    [SerializeField] XRSocketInteractor BottomRightSocket;
    [SerializeField] GameObject YellowBattery;
    [SerializeField] GameObject RedBattery;
    [SerializeField] GameObject GreenBattery;
    [SerializeField] GameObject BlueBattery;

    public static UnityAction Riddle1Complete;

    private const int TOP_LEFT = 0;
    private const int TOP_RIGHT = 1;
    private const int BOTTOM_LEFT = 2;
    private const int BOTTOM_RIGHT = 3;

    private bool[] state;
    // Start is called before the first frame update
    void Start()
    {
        state = new bool[4];
    }


    public void BatteryInserted(int socketID)
    {
        int batteryID = int.Parse(GetSocketFromID(socketID).firstInteractableSelected.transform.name.Split(' ')[1]);
        Debug.Log(batteryID);
        if(batteryID == socketID)
        {
            state[socketID] = true;
            CheckComplete();
        }
    }

    public void BatteryRemoved(int socketID)
    {
        Debug.Log(socketID);
        state[socketID] = false;
    }

    private void CheckComplete()
    {
        bool  complete = true;
        foreach(bool socketState in state)
        {
            if (!socketState)
            {
                complete = false;
            }
        }

        if (complete)
        {
            Riddle1Complete.Invoke();
        }
    }

    private XRSocketInteractor GetSocketFromID(int socketID)
    {
        XRSocketInteractor socket = null;
        switch(socketID)
        {
            case TOP_LEFT:
                socket = TopLeftSocket;
                break;
            case TOP_RIGHT:
                socket = TopRightSocket;
                break;
            case BOTTOM_LEFT:
                socket = BottomLeftSocket;
                break;
            case BOTTOM_RIGHT:
                socket = BottomRightSocket;
                break;
        }
        return socket;
    }

    public void SolveRiddle()
    {
        YellowBattery.transform.rotation = new Quaternion(0f, 0f, 0f,0f);
        YellowBattery.transform.position = new Vector3(-4.65f, 1.95f, -2.1f);
        
        RedBattery.transform.position = new Vector3(-4.95f, 1.95f, -2.1f);
        RedBattery.transform.rotation = new Quaternion(0f, 0f, 0f,0f);

        GreenBattery.transform.position = new Vector3(-4.65f, 1.95f, -1.8f);
        GreenBattery.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        BlueBattery.transform.position = new Vector3(-4.95f, 1.95f, -1.8f);
        BlueBattery.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        Riddle1Complete.Invoke();
    }
}
