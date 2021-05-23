using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayerTransition : MonoBehaviour
{
    public Transform next_spot;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            UIManager.Instance.Fade(next_spot.position);
        }
    }
}
