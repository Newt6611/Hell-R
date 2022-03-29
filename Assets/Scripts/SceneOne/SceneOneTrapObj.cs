using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneTrapObj : MonoBehaviour
{
    public float speed = 13; 
    
    public bool right = true;

    private void Start()
    {
        Invoke("DestroyObj", 7);
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(right)
            transform.position = new Vector3(transform.position.x + 20 * Time.deltaTime, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - 20 * Time.deltaTime, transform.position.y, transform.position.z);
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
