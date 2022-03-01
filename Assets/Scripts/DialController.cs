using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour, IDial
{
    [SerializeField] float curAngle;
    [SerializeField] int dialNum;
    [SerializeField] Riddle2Controller riddle;

    public void DialChanged(float dialvalue)
    {
        curAngle = dialvalue;
        riddle.DialChanged(dialNum, dialvalue);
        
    }

    public float CurAngle
    {
        get { return curAngle; }
    }


}
