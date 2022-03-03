using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    [SerializeField] Animator ShieldCoreAnim;
    [SerializeField] Animator DoorAnim;
    [SerializeField] TextMeshProUGUI stationStatusText;
    [SerializeField] GameObject outSideTeleportArea;

    public static UnityAction BreakDown;



    private bool shieldCoreWorking;
    
    // Start is called before the first frame update
    void Start()
    {
        outSideTeleportArea.SetActive(false);
        Riddle1Controller.Riddle1Complete += OnRiddle1Complete;
        Riddle2Controller.Riddle2Complete += OnRiddle2Complete;
        Riddle3Controller.Riddle3Complete += OnRiddle3Complete;


        Invoke("Riddle1Setup", 5f);
    }



    

    private void Riddle1Setup()
    {
        ShieldCoreAnim.SetBool("Generator Working", false);
        //Play engine failing audio
        //Start electric particles
        stationStatusText.text = "Full System failure, insert batteries to emergency capacitor to restart backup generator";
        BreakDown.Invoke();


    }

    private void Riddle2Setup()
    {

        //Activate sencond station
        stationStatusText.text = "Backup power online, regulate cooling and shields in the station control unit";
    }

    private void Riddle3Setup()
    {

        DoorAnim.SetBool("character_nearby", true);
        stationStatusText.text = "Station lockdown lifted, repair generator outside of station";
        outSideTeleportArea.SetActive(true);
    }

    private void OnRiddle1Complete()
    {
        Debug.Log("1 complete");
        ShieldCoreAnim.SetBool("Generator Working", true);
        Riddle2Setup();
    }
    
    private void OnRiddle2Complete()
    {
        Riddle3Setup();
    }
    
    private void OnRiddle3Complete()
    {
        stationStatusText.text = "Yay";
    }

}
