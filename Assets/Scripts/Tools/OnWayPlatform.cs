using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWayPlatform : MonoBehaviour
{
    public bool is_up;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            transform.parent.GetComponent<Collider2D>().enabled = is_up;
    }
}
