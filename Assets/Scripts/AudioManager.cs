using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager m_instance;
    public static AudioManager Instance { get { return m_instance; } }

    [Header("SceneOne")]
    [SerializeField] private AudioClip F;
    [SerializeField] private AudioClip G;
    [SerializeField] private AudioClip A;
    [SerializeField] private AudioClip B;
    [SerializeField] private AudioClip C;

    public AudioClip open_door;

    private AudioSource audio_source;

    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        audio_source = GetComponent<AudioSource>();
    }

    public void PlayOpenDoor()
    {
        audio_source.PlayOneShot(open_door, 0.75f);
    }

    public void PlayOneShot(AudioClip clip)
    {
        audio_source.PlayOneShot(clip);
    }

    public void PlayOneShot(AudioClip clip, float volumn)
    {
        audio_source.volume = volumn;
        audio_source.PlayOneShot(clip);
    }

    public void PlayOneShot(MusicNotes note) 
    {
        switch(note)
        {
            case MusicNotes.note_one:
                audio_source.PlayOneShot(F);
                break;
            case MusicNotes.note_two:
                audio_source.PlayOneShot(G);
                break;
            case MusicNotes.note_three:
                audio_source.PlayOneShot(A);
                break;
            case MusicNotes.note_four:
                audio_source.PlayOneShot(B);
                break;
            case MusicNotes.note_five:
                audio_source.PlayOneShot(C);
                break;
        }
    }

    public void Play(AudioClip clip)
    {
        audio_source.volume = 1;
        audio_source.clip = clip;
        audio_source.Play();
    }

    public void Stop() 
    {
        audio_source.Stop();
    }
}
