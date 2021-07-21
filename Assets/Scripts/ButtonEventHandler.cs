using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonEventHandler : MonoBehaviour, ISelectHandler
{
    public AudioClip clip;

    public void OnSelect(BaseEventData eventData)
    {
        AudioManager.Instance.PlayOnShot(clip);
    }
}
