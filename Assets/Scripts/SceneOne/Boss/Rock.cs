using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Sprite rock_one;
    public Sprite rock_two;
    [HideInInspector] public SpriteRenderer sprite_renderer;

    private void Start() 
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        int index = Random.Range(0, 2);
        sprite_renderer.sprite = index == 0 ? rock_one : rock_two;
        Invoke("DestroyOBJ", 5);
    }

    private void Update() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.TakeDamage(transform, 1);
            Destroy(this.gameObject);
        }
    }


    private void DestroyOBJ()
    {
        if(gameObject != null)
            Destroy(this.gameObject);
    }
}