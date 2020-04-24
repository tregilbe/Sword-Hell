using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffects : MonoBehaviour
{
    public AudioSource EffectsAudio;
    public AudioClip clipToPlay;

    // Start is called before the first frame update
    void Start()
    {
        EffectsAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Play()
    {
        AudioSource.PlayClipAtPoint(clipToPlay, new Vector3 (0, 0, 0));
    }
}
