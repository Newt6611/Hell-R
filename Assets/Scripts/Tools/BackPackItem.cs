using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackItem : MonoBehaviour
{
    public GameObject bar;
    private bool is_selected;
    [SerializeField] private Image sprite_renderer;

    public void Use()
    {
        // Todo
    }

    public void SetSprite(Sprite sprite)
    {
        sprite_renderer.enabled = true;
        sprite_renderer.sprite = sprite;
    }

    public void Select() 
    {
        bar.SetActive(true);
        is_selected = true;
    }
    
    public void UnSelect()
    {
        bar.SetActive(false);
        is_selected = false;
    }

    public bool IsSelected()
    {
        return is_selected;
    }

    public bool IsEmpty()
    {
        return sprite_renderer.sprite == null;
    }
}
