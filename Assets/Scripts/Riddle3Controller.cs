using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Riddle3Controller : MonoBehaviour
{
    [SerializeField] Animator generatorAnim;
    [SerializeField] List<FirestreamContoller> flameStreams = new List<FirestreamContoller>();

    public static UnityAction Riddle3Complete;

    private bool[] state;

    // Start is called before the first frame update
    void Start()
    {
        state = new bool[3];
        foreach(FirestreamContoller flameStream in flameStreams)
        {
            flameStream.Stop();
        }
        GameController.BreakDown += Init;
        
    }

    

    public void FireExtinguished(int fireNum)
    {
        state[fireNum] = true;
        CheckComplete();
    }

    private void CheckComplete()
    {
        bool complete = true;
        foreach (bool flameState in state)
        {
            if (!flameState)
            {
                complete = false;
            }
        }

        if (complete)
        {
            Riddle3Complete.Invoke();
            generatorAnim.SetBool("Fixed", true);
        }
    }

    private void Init()
    {
        foreach (FirestreamContoller flameStream in flameStreams)
        {
            flameStream.Play();
        }
        generatorAnim.SetBool("Fixed", false);
    }

    public void SolveRiddle()
    {
        foreach (FirestreamContoller flameStream in flameStreams)
        {
            flameStream.Stop();
        }
        generatorAnim.SetBool("Fixed", true);
        Riddle3Complete.Invoke();
    }


}
