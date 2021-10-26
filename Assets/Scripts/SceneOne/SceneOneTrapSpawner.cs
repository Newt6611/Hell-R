using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneTrapSpawner : MonoBehaviour
{
    public float start_time = 3f;
    private float time_btw;

    public bool right = true;

    public GameObject[] objects;

    public Transform[] positions;

    private bool shooting = true;

    private void Start() 
    {
        time_btw = start_time;
    }

    private void Update()
    {
        if(time_btw <= 0)
            Shoot();
        else
            time_btw -= Time.deltaTime;
    }
    
    private void Shoot()
    {
        time_btw = start_time;
        GameObject t = Instantiate(objects[Random.Range(0, objects.Length)], positions[Random.Range(0, positions.Length)].position, Quaternion.Euler(0f, 180f, 0f));
        if(!right)
        {
            t.GetComponent<SceneOneTrapObj>().right = false;
            t.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
