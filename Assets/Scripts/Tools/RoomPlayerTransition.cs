using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomPlayerTransition : MonoBehaviour
{
    public Transform next_spot;

    public bool keybord_input;

    [Range(0, 5)]
    public int key_note;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(keybord_input && other.CompareTag("Player"))
        {
            Player.Instance.player_into_door_use_keyboard += Into;
            
            GetComponentInChildren<FloatingTexture>().enabled = true;
        }
        else if(!keybord_input)
        {
            if(other.CompareTag("Player"))
            {
                Into();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player.Instance.player_into_door_use_keyboard -= Into;
        if(keybord_input)
            GetComponentInChildren<FloatingTexture>().enabled = false;
    }

    private void Into() 
    {
        SceneOneMonsterSpawner.Instance.UpdateIsSpawn();
        
        SceneOneManager.Instance.ShowNote(key_note);

        if(keybord_input)
            AudioManager.Instance.PlayOpenDoor();

        if(next_spot == null)
        {
            UIManager.Instance.Fade(Player.Instance.pre_pos.position);
        }
        else
        {
            UIManager.Instance.Fade(next_spot.position);
        }
        Player.Instance.pre_pos = transform;
    }
}
