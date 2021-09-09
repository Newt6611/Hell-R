using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneCriminal : MonoBehaviour, IEnemy
{
    public Sprite idle;
    public Sprite hited_one;
    public Sprite hited_two;
    public Sprite sit;
    private SpriteRenderer sprite_renderer;
    private Rigidbody2D rigidbody2D;

    private bool dispear;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = idle;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() 
    {
        if(dispear)
        {
            float alpha = sprite_renderer.color.a;
            alpha -= Time.deltaTime;
            Color color = new Color(sprite_renderer.color.r, sprite_renderer.color.g, sprite_renderer.color.b, alpha);
            sprite_renderer.color = color;

            if(sprite_renderer.color.a <= 0)
                Destroy(gameObject);
        }
    }

    public void TakeDamage(int d) 
    {
        gameObject.layer = 11; // un_attackable layer
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        transform.rotation = Quaternion.identity;
        StartCoroutine(PlaySprite());
    }

    IEnumerator PlaySprite()
    {
        sprite_renderer.sprite = hited_one;
        yield return new WaitForSeconds(0.4f);
        sprite_renderer.sprite = hited_two;

        yield return new WaitForSeconds(0.5f);
        sprite_renderer.sprite = sit;

        yield return new WaitForSeconds(5);
        dispear = true;
    }

    private void PlaySprite(Sprite sprite)
    {
        sprite_renderer.sprite = sprite;
    }

    public void SetMode(bool b) { }

    public void SetSpawner(SceneOneMonsterSpawner spawner) { }
}
