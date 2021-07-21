using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager m_instance;
    public static AudioManager Instance { get { return m_instance; } }

    private AudioSource audio_source;

    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        audio_source = GetComponent<AudioSource>();
    }

    public void PlayOnShot(AudioClip clip)
    {
        audio_source.PlayOneShot(clip);
    }
}
