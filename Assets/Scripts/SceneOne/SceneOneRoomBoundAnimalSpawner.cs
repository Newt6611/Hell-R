using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneRoomBoundAnimalSpawner : MonoBehaviour
{
    public GameObject[] animals;
    public Transform spawn_pos;
    public Transform trigger_pos;
    private GameObject has_animal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if((other.transform.position.x - trigger_pos.position.x) <= 0 && !HasAnimal())
            {
                int index = Random.Range(0, 2);
                has_animal = Instantiate(animals[index], spawn_pos.position, animals[index].transform.rotation);
            }
            else if((other.transform.position.x - trigger_pos.position.x) > 0 && HasAnimal())
            {
                Invoke("D", 0.7f);
            }
        }
    }

    private bool HasAnimal()
    {
        return has_animal != null;
    }

    private void D() 
    {
        Destroy(has_animal);
    }
}
