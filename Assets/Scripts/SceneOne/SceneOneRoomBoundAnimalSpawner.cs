using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneRoomBoundAnimalSpawner : MonoBehaviour
{
    public GameObject[] animals;
    public Transform spawn_pos;
    public Transform trigger_pos;
    public SceneOneCriminal has_animal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if((other.transform.position.x - trigger_pos.position.x) <= 0)
            {
                if(has_animal == null)
                {
                    int index = Random.Range(0, 2);
                    has_animal = Instantiate(animals[index], spawn_pos.position, animals[index].transform.rotation).GetComponent<SceneOneCriminal>();
                    has_animal.SetParent(this);
                }
            }
            else if((other.transform.position.x - trigger_pos.position.x) > 0)
            {
                if(has_animal)
                    Invoke("D", 0.3f);
            }
        }
    }

    private bool HasAnimal()
    {
        return has_animal != null;
    }

    private void D() 
    {
        Destroy(has_animal.gameObject);
        has_animal = null;
    }
}
