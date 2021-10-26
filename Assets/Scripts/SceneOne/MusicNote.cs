using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicNote : MonoBehaviour
{
    public MusicNotes note;
    private bool show;

    private SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update() 
    {
        if(IsPlayerGetted() && !show)
        {
            show = true;
            spriteRenderer.enabled = true;
        }
    }

    private bool IsPlayerGetted()
    {
        int i = Convert.ToInt32(note) & SceneOneManager.Instance.music_notes;
        return i != 0;
    }
    
}
