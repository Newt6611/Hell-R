using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectNote : MonoBehaviour
{
    public MusicNotes note;

    private FloatingTexture floating_texture;

    private bool selected = false;

    private void Start() 
    {
        floating_texture = GetComponent<FloatingTexture>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !selected)
        {
            Player.Instance.player_into_door_use_keyboard += Get;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.player_into_door_use_keyboard -= Get;
        }
    }

    private void Get() 
    {
        UIManager.Instance.animator.Play("show_music_note");
        UIManager.Instance.SetMusicRoomNoteAnimation(note);
        AudioManager.Instance.PlayOneShot(note);

        SceneOneManager.Instance.GetNote(note);
        selected = true;
        DOTween.Kill(floating_texture.transform);
    }
}
