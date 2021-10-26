using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyboard : MonoBehaviour
{
    [Range(1, 7)]
    public int key;
    
    [SerializeField] private GameObject select_bar;
    
    public void Select() 
    {
        select_bar.SetActive(true);
    }

    public void UnSelect()
    {
        select_bar.SetActive(false);
    }
}
