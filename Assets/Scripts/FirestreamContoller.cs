using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirestreamContoller : MonoBehaviour
{
    [SerializeField] Riddle3Controller riddle;
    [SerializeField] int flameNum;
    
    private ParticleSystem flames;
    private bool extinguished;

    // Start is called before the first frame update
    void Start()
    {
        flames = GetComponent<ParticleSystem>();
        extinguished = false;
    }



    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "ExtinguisherParticle" && !extinguished)
        {
            extinguished = true;
            flames.Stop();
            riddle.FireExtinguished(flameNum);
        }
    }
}
