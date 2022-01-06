using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalSparksController : MonoBehaviour
{
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
    [SerializeField] private List<AudioClip> sparksSFX = new List<AudioClip>();

    private ParticleSystem particles;
    private AudioSource audioSource;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        particles.Stop();
        timer = Random.Range(minTimer, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            audioSource.clip = sparksSFX[Random.Range(0, sparksSFX.Count)];
            audioSource.Play();
            particles.Play();
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
