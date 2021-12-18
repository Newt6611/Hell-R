using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class FloatingTexture : MonoBehaviour
{
    public InputReader inputReader;

    public Sprite keyboardSprite;
    public Sprite controllerSprite;

    public float speed = 0.5f;
    public float height = 1;

    private SpriteRenderer renderer;
    
    private void Awake()
    {
        inputReader.controlChangeEvent += OnControllerChange;
        renderer = GetComponent<SpriteRenderer>();

        if(keyboardSprite != null)
            renderer.sprite = keyboardSprite;
        transform.DOMoveY(transform.position.y + height, speed).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnControllerChange(string scheme) 
    {
        if(scheme == "GamePad" && controllerSprite != null)
            renderer.sprite = controllerSprite; 
        else if(scheme == "KeyBoard" && keyboardSprite != null)
            renderer.sprite = keyboardSprite;
    }

    private void OnEnable()
    {
        renderer.enabled = true;
    }

    private void OnDisable()
    {
        renderer.enabled = false;
    }
}
