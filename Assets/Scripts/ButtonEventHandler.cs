using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEventHandler : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public AudioClip clip;

    [SerializeField] private Image selected_image;

    public void OnSelect(BaseEventData eventData)
    {
        AudioManager.Instance.PlayOneShot(clip);
        selected_image.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selected_image.enabled = false;
    }
}
