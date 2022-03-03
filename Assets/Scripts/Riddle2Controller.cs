using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Riddle2Controller : MonoBehaviour
{

    public static UnityAction Riddle2Complete;

    [SerializeField] List<GameObject> screens = new List<GameObject>();
    [SerializeField] List<XRGrabInteractable> interactables = new List<XRGrabInteractable>();

    [SerializeField] Image screen1Frame;
    [SerializeField] TextMeshProUGUI shieldStatusText;
    [SerializeField] Image outerShieldBar;
    [SerializeField] Image innerShieldBar;
    [SerializeField] Image totalShieldBar;

    [SerializeField] Image screen2Frame;
    [SerializeField] TextMeshProUGUI stationStatusText;

    [SerializeField] Image screen3Frame;
    [SerializeField] TextMeshProUGUI coolingOnText;
    
    private ShieldStatus shieldStatus;
    private float stabilizingTimer;
    private float outerShieldPower;
    private float innerShieldPower;
    private float totalShieldPower;
    private bool mainCoolingOn;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject screen in screens)
        {
            screen.SetActive(false);
        }

        foreach(XRGrabInteractable interactable in interactables)
        {
            interactable.enabled = false;
        }
        Riddle1Controller.Riddle1Complete += Init;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(shieldStatus == ShieldStatus.stabilizing)
        {
            stabilizingTimer -= Time.deltaTime;
            if (stabilizingTimer <= 0)
            {
                shieldStatus = ShieldStatus.stable;
                updateShieldScreen();
                Riddle2Complete.Invoke();
            }
        }
    }

    public void DialChanged(int dialNum, float newAngle)
    {
        
        float result = Mathf.InverseLerp(0, 180, newAngle);
        if(dialNum == 1)
        {
            outerShieldPower = result;
        }
        else
        {
            innerShieldPower = result;
        }

        totalShieldPower = Mathf.InverseLerp(0f, 1.5f, outerShieldPower + 0.5f * innerShieldPower);
        if (totalShieldPower < 0.78f)
        {
            shieldStatus = ShieldStatus.underpowered;
        }else if(totalShieldPower > 0.82f)
        {
            shieldStatus = ShieldStatus.overpowered;
        }
        else
        {
            shieldStatus = ShieldStatus.stabilizing;
            stabilizingTimer = 3f;
        }
        updateShieldScreen();
    }

    public void LeverChanged(bool leverState)
    {
        mainCoolingOn = leverState;
        updateCoolingScreen();
    }

    private void updateCoolingScreen()
    {
        if (mainCoolingOn)
        {
            screen3Frame.color = Color.green;
            coolingOnText.text = "ON";
        }
        else
        {
            screen3Frame.color = Color.red;
            coolingOnText.text = "OFF";
        }
        updateStatusScreen();
    }

    private void updateShieldScreen()
    {
        if(shieldStatus != ShieldStatus.stable)
        {
            screen1Frame.color = Color.red;
        }
        else
        {
            screen1Frame.color = Color.green;
        }

        outerShieldBar.rectTransform.localScale = new Vector3(1,outerShieldPower);
        innerShieldBar.rectTransform.localScale = new Vector3(1, innerShieldPower);
        totalShieldBar.rectTransform.localScale = new Vector3(1, totalShieldPower);
        Color shieldbarColor;
        if (shieldStatus == ShieldStatus.underpowered)
        {
            shieldbarColor = Color.grey;
            shieldStatusText.text = "Underpowered";
        } else if (shieldStatus == ShieldStatus.overpowered)
        {
            shieldbarColor = Color.red;
            shieldStatusText.text = "OverPowered";
        }
        else if (shieldStatus == ShieldStatus.stabilizing)
        {
 
            shieldbarColor = Color.yellow;
            shieldStatusText.text = "Stabilizing";
        }
        else
        {
            shieldbarColor = Color.green;
            shieldStatusText.text = "Stable";
        }
        totalShieldBar.color = shieldbarColor;
        updateStatusScreen();
    }
    private void updateStatusScreen()
    {
        string status = "";
        status += mainCoolingOn ? "Cooling: Up\n" : "Cooling: Down\n";
        status += (shieldStatus == ShieldStatus.stable) ? "Shields: Up" : "Shields: Down";
        stationStatusText.text = status;
        if(mainCoolingOn && shieldStatus == ShieldStatus.stable)
        {
            screen2Frame.color = Color.green;
        }
        else
        {
            screen2Frame.color = Color.red;
        }
    }

    private void Init()
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(true);
        }

        foreach (XRGrabInteractable interactable in interactables)
        {
            interactable.enabled = true;
        }

        shieldStatus = ShieldStatus.underpowered;
        stabilizingTimer = 3f;
        outerShieldPower = 0f;
        innerShieldPower = 0f;
        mainCoolingOn = false;

        updateCoolingScreen();
        updateShieldScreen();
        updateStatusScreen();
    }

    public void SolveRiddle()
    {
        mainCoolingOn = true;
        outerShieldPower = 1f;
        innerShieldPower = 0.5f;
        totalShieldPower = 0.8f;
        shieldStatus = ShieldStatus.stable;
        updateCoolingScreen();
        updateShieldScreen();
        updateStatusScreen();
        Riddle2Complete.Invoke();
    }

    private enum ShieldStatus
    {
        underpowered,
        overpowered,
        stabilizing,
        stable
    }
}
