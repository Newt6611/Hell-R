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

    [SerializeField] private GameObject purple_particle_pre;
    private GameObject purplr_particle = null;

    private SceneOneRoomBoundAnimalSpawner parent;

    private bool particl_start_moving = false;
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

        if(particl_start_moving && purplr_particle != null)
        {
            purplr_particle.transform.position = Vector2.MoveTowards(purplr_particle.transform.position, SceneOneManager.Instance.HateValuePos.position, 15 * Time.deltaTime);
            if(Vector2.Distance(purplr_particle.transform.position, SceneOneManager.Instance.HateValuePos.position) < 0.2f)
            {
                SceneOneManager.Instance.Current_Hate_Value -= 10f;
                Destroy(purplr_particle);
            }
        }
    }

    public void TakeDamage(int d) 
    {
        Player.Instance.Heal((int)(Player.Instance.TotalHealth * 0.25));
        gameObject.layer = 11; // un_attackable layer
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        transform.rotation = Quaternion.identity;

        purplr_particle = Instantiate(purple_particle_pre, transform.position, Quaternion.identity);
        particl_start_moving = true;

        if(parent.has_animal != null)
            parent.has_animal = null;

        StartCoroutine(PlaySprite());
    }

    public void SetParent(SceneOneRoomBoundAnimalSpawner spawner)
    {
        parent = spawner;
    }

    IEnumerator PlaySprite()
    {
        sprite_renderer.sprite = hited_one;
        yield return new WaitForSeconds(0.3f);
        sprite_renderer.sprite = hited_two;

        yield return new WaitForSeconds(0.3f);
        sprite_renderer.sprite = sit;

        yield return new WaitForSeconds(0.5f);
        dispear = true;
    }

    private void PlaySprite(Sprite sprite)
    {
        sprite_renderer.sprite = sprite;
    }

    public void SetMode(bool b) { }

    public void SetSpawner(SceneOneMonsterSpawner spawner) { }
}
