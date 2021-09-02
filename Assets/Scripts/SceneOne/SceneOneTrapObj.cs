using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneTrapObj : MonoBehaviour
{
    public float speed = 20; 
    
    private void Update()
    {
        transform.position = new Vector3(transform.position.x + 20 * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.TakeDamage(transform, 1);
            Destroy(gameObject);
        }
    }
}
