using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    [HideInInspector] public Rigidbody2D rigidbody;
    [HideInInspector] public Animator animator;
    public Transform fly_pos;
    public Transform boss_pos;

    private bool start_fly = false;
    private Vector3 temp_player_pos;
    

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("idle");
    }

    private void FixedUpdate()
    {
        if(start_fly)
        {
            if(Vector2.Distance(transform.position, fly_pos.position) >= 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, fly_pos.position, 20 * Time.fixedDeltaTime);
                transform.localScale = new Vector3(1,1,1);
            }
            else
                animator.Play("slow");
        }
    }

    public void Shoot() 
    {
        start_fly = false;
        Vector2 player_dir = temp_player_pos - transform.position;
        player_dir.y = -4.5f;
        rigidbody.AddForce(player_dir.normalized * 40, ForceMode2D.Impulse);
        animator.Play("shoot");
    }

    private void StartFly() => start_fly =  true;

    private void CatchPlayerPos() => temp_player_pos = Player.Instance.transform.position;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Player.Instance.TakeDamage(boss_pos, 1);    
            Destroy(this.gameObject);
        }
    }
}
