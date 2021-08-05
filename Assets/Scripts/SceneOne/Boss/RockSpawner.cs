using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public Transform[] positions;

    public Rock rock_pre;

    public void StartRock()
    {
        StartCoroutine(DelaySpawn(0, positions));
    }

    private IEnumerator DelaySpawn(int index, Transform[] pos) 
    {
        yield return new WaitForSeconds(0.3f);
        if(index < pos.Length)
        {
            Instantiate(rock_pre, pos[index].position, Quaternion.identity);
            StartCoroutine(DelaySpawn(index+1, positions));
        }
    }
}
