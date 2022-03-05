using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource stationSpeaker;
    [SerializeField] AudioSource GeneratorAudioSource;
    [SerializeField] List<AudioClip> stationSpeakerLines;
    

    public void PlayStationSpeakerLine(int lineNum)
    {
        stationSpeaker.clip = stationSpeakerLines[lineNum];
        stationSpeaker.Play();
    }

    public void PlayGeneratorExplosion()
    {
        GeneratorAudioSource.Play();
    }
}
