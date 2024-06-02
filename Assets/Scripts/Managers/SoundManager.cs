using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip FinishClip;
    [SerializeField] private AudioClip MatchClip;
    [SerializeField] private AudioClip MismatchClip;
    
    private AudioSource AudioSource;

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        Core.Events.OnFinishLevel += OnFinish;
        Core.Events.OnMatch += OnMatch;
        Core.Events.OnMismatch += OnMismatch;
    }

    private void OnDestroy()
    {
        Core.Events.OnFinishLevel -= OnFinish;
        Core.Events.OnMatch -= OnMatch;
        Core.Events.OnMismatch -= OnMismatch;
    }

    private void OnFinish(int score)
    {
        AudioSource.PlayOneShot(FinishClip);
    }
    
    private void OnMatch()
    {
        AudioSource.PlayOneShot(MatchClip);
    }
    
    private void OnMismatch()
    {
        AudioSource.PlayOneShot(MismatchClip);
    }
}
