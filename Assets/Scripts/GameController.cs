using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] Animator ShieldCoreAnim;


    private bool shieldCoreWorking;
    
    // Start is called before the first frame update
    void Start()
    {
        Riddle1Controller.Riddle1Complete += OnRiddle1Complete;
        Riddle2Controller.Riddle2Complete += OnRiddle2Complete;
        Invoke("Riddle1Setup", 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void Riddle1Setup()
    {
        ShieldCoreAnim.SetBool("Generator Working", false);
        //Play engine failing audio
        //Start electric particles
        //Change backup engine lights

    }

    private void Riddle2Setup()
    {
        //stop backup engine lights
        //Activate sencond station
        
    }

    private void Riddle3Setup()
    {
        //Open door
    }

    private void OnRiddle1Complete()
    {
        Debug.Log("1 complete");
        ShieldCoreAnim.SetBool("Generator Working", true);
        Riddle2Setup();
    }
    
    private void OnRiddle2Complete()
    {
        throw new NotImplementedException();
    }
    
    private void OnRiddle3Complete()
    {
        throw new NotImplementedException();
    }

}
