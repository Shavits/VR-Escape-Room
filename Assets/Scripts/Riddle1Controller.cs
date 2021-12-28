using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Riddle1Controller : MonoBehaviour
{

    [SerializeField] XRSocketInteractor TopLeftSocket;
    [SerializeField] XRSocketInteractor TopRightSocket;
    [SerializeField] XRSocketInteractor BottomLeftSocket;
    [SerializeField] XRSocketInteractor BottomRightSocket;

    private const int TOP_LEFT = 0;
    private const int TOP_RIGHT = 1;
    private const int BOTTOM_LEFT = 2;
    private const int BOTTOM_RIGHT = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BatteryInserted(int socketID)
    {
        string batteryID = GetSocketFromID(socketID).firstInteractableSelected.transform.name;
        Debug.Log(socketID+ ":" + batteryID);
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
}
