using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherContoller : MonoBehaviour
{
    [SerializeField] ParticleSystem foamParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFoam(bool foamOn)
    {
        if (foamOn)
        {
            foamParticle.Play();
        }
        else
        {
            foamParticle.Stop();
        }
    }
}
