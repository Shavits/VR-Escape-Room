using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] Animator ShieldCoreAnim;
    [SerializeField] Animator DoorAnim;
    [SerializeField] TextMeshProUGUI stationStatusText;
    [SerializeField] GameObject outSideTeleportArea;
    [SerializeField] AudioController audioController;

    public static UnityAction BreakDown;

    private bool shieldCoreWorking;
    private TrialLogger trialLogger;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        outSideTeleportArea.SetActive(false);
        Riddle1Controller.Riddle1Complete += OnRiddle1Complete;
        Riddle2Controller.Riddle2Complete += OnRiddle2Complete;
        Riddle3Controller.Riddle3Complete += OnRiddle3Complete;
        trialLogger = GetComponent<TrialLogger>();
        List<string> columnHeaders = new List<string> { "Riddle1", "Riddle2", "Riddle3" };
        int ppid = PlayerPrefs.HasKey("PPID") ? (PlayerPrefs.GetInt("PPID") + 1) : 0;
        PlayerPrefs.SetInt("PPID", ppid);
        PlayerPrefs.Save();
        trialLogger.Initialize(ppid.ToString(), columnHeaders);
        trialLogger.StartTrial();
        timer = 0;


        Invoke("Riddle1Setup", 10f);
    }


    private void Update()
    {
        timer += Time.deltaTime;
    }


    private void Riddle1Setup()
    {
        ShieldCoreAnim.SetBool("Generator Working", false);
        audioController.PlayGeneratorExplosion();
        stationStatusText.text = "Full System failure, insert batteries to emergency capacitor to restart backup generator";
        audioController.PlayStationSpeakerLine(0);
        BreakDown.Invoke();
    }

    private void Riddle2Setup()
    {
        stationStatusText.text = "Backup power online, regulate cooling and shields in the station control unit";
        audioController.PlayStationSpeakerLine(1);
    }

    private void Riddle3Setup()
    {
        stationStatusText.text = "Station lockdown lifted, repair generator outside of station";
        audioController.PlayStationSpeakerLine(2);
    }

    private void OnRiddle1Complete()
    {
        ShieldCoreAnim.SetBool("Generator Working", true);
        trialLogger.trial["Riddle1"] = timer.ToString();
        Riddle2Setup();
    }
    
    private void OnRiddle2Complete()
    {
        DoorAnim.SetBool("character_nearby", true);
        outSideTeleportArea.SetActive(true);
        trialLogger.trial["Riddle2"] = timer.ToString();
        Riddle3Setup();
    }
    
    private void OnRiddle3Complete()
    {
        stationStatusText.text = "All Systems back online, well done";
        audioController.PlayStationSpeakerLine(3);
        float totalTime = timer;
        UpdateHighScore(totalTime);
        trialLogger.trial["Riddle3"] = timer.ToString();
        trialLogger.EndTrial();
        Invoke("GameOver", 5f);
        
    }

    private void UpdateHighScore(float time)
    {
        if(PlayerPrefs.HasKey("First Place") && time < PlayerPrefs.GetFloat("First Place"))
        {
            PlayerPrefs.SetFloat("First Place", time);
        }
        else if(PlayerPrefs.HasKey("Second Place") && time < PlayerPrefs.GetFloat("Second Place"))
        {
            PlayerPrefs.SetFloat("Second Place", time);
        }else if(PlayerPrefs.HasKey("Third Place") && time < PlayerPrefs.GetFloat("Third Place"))
        {
            PlayerPrefs.SetFloat("Third Place", time);
        }
        else if (!PlayerPrefs.HasKey("First Place"))
        {
            PlayerPrefs.SetFloat("First Place", time);
        }else if(!PlayerPrefs.HasKey("Second Place"))
        {
            PlayerPrefs.SetFloat("Second Place", time);
        }else if(!PlayerPrefs.HasKey("Third Place"))
        {
            PlayerPrefs.SetFloat("Third Place", time);
        }
        PlayerPrefs.Save();
       
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
