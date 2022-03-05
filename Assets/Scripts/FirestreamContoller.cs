using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirestreamContoller : MonoBehaviour
{
    [SerializeField] Riddle3Controller riddle;
    [SerializeField] int flameNum;
    
    private ParticleSystem flames;
    private AudioSource audioSource;
    private bool extinguished;

    // Start is called before the first frame update
    void Start()
    {
        flames = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        extinguished = false;
    }



    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "ExtinguisherParticle" && !extinguished)
        {
            extinguished = true;
            Stop();
            riddle.FireExtinguished(flameNum);
        }
    }

    public void Play()
    {
        flames.Play();
        audioSource.Play();
    }

    public void Stop()
    {
        flames.Stop();
        audioSource.Stop();
    }
}
