using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTrigger : MonoBehaviour
{
    private int current_keybaord;

    private FloatingTexture floating_texture;
    private SpriteRenderer sprite_renderer;

    public InputReader input_reader;

    private void Start() 
    {
        floating_texture = GetComponent<FloatingTexture>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.enabled = false;
        current_keybaord = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(PianoManager.Instance.is_opened)
            return;
        if(other.tag == "Player")
        {
            Player.Instance.player_into_door_use_keyboard += OpenPiano;
            sprite_renderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.player_into_door_use_keyboard -= OpenPiano;
            sprite_renderer.enabled = false;
        }
    }

    private void OpenPiano()
    {
        if(PianoManager.Instance.is_opened)
            return;
        Player.Instance.Disable();
        input_reader.DisablePlayer();
        PianoManager.Instance.Show();
        sprite_renderer.enabled = false;
        UIManager.Instance.animator.Play("show_piano");
    }
}
