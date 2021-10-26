using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingTexture : MonoBehaviour
{
    public Sprite sprite;

    public float speed = 0.5f;
    public float height = 1;

    private SpriteRenderer renderer;
    
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        if(sprite != null)
            renderer.sprite = sprite;
        transform.DOMoveY(transform.position.y + height, speed).SetLoops(-1, LoopType.Yoyo);
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
