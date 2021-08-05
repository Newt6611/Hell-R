using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomCameraChange : MonoBehaviour
{
    public GameObject virtual_cam;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
            virtual_cam.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
            virtual_cam.SetActive(false);
    }
}
