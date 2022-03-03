using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField] Riddle1Controller riddle1;
    [SerializeField] Riddle2Controller riddle2;
    [SerializeField] Riddle3Controller riddle3;
    
    public void SolveRiddle1()
    {
        riddle1.SolveRiddle();
    }

    public void SolveRiddle2()
    {
        riddle2.SolveRiddle();
    }
    public void SolveRiddle3()
    {
        riddle3.SolveRiddle();
    }
}
