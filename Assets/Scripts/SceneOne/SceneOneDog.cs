using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dog_State {
    idle, attack, run, hited, died
}

public class SceneOneDog : MonoBehaviour, IEnemy
{

    [SerializeField] bool DrawGizmos;
    [SerializeField] private float find_player_radius;
    [SerializeField] private float attack_radius;

    [SerializeField] private float speed;

    private bool face_right = true;

    private int health = 3;

    private Dog_State current_state;

    // Components
    private Rigidbody2D rb;
    private Animator ani;

    private void Start()
    {
        current_state = Dog_State.idle;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        ani.Play("idle");
    }

    private void Update() 
    {
        // if not idle state then do flip behavior;
        FlipBehavior();
    }

    private void FixedUpdate()
    {
        switch(current_state) 
        {
            case Dog_State.idle:
                IdleState();
                break;
            case Dog_State.run:
                RunState();
                break;
            case Dog_State.attack:
                AttackState();
                break;
            case Dog_State.hited:
                HitedState();
                break;
            case Dog_State.died:
                DiedState();
                break;
        }    
    }


    private void IdleState() 
    {
        // find player is in area to chase
        if(Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
        {
            ChangeState(Dog_State.run);
        }
    }

    private void RunState()
    {
        if(Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
            ChangeState(Dog_State.attack);

        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.fixedDeltaTime);

        // if too far, then back to idle state
        if(!Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
            ChangeState(Dog_State.idle);
    }

    private void AttackState() { }

    private void HitedState() 
    {
        float dir = Player.Instance.transform.position.x - transform.position.x;
        if(dir >= 0)
            rb.AddForce(Vector2.left * 3f, ForceMode2D.Impulse);
        else
            rb.AddForce(Vector2.right * 3f, ForceMode2D.Impulse);
    }

    private void DiedState()
    {
        StartCoroutine(DiedDelay(3));
    }

    private IEnumerator DiedDelay(float ts) 
    {
        yield return new WaitForSeconds(ts);
        Destroy(this.gameObject);
    }

    private void ChangeState(Dog_State next_state) 
    {
        if(current_state == next_state)
            return;

        current_state = next_state;
        PlayeAnimation(next_state);
    }

    private void PlayeAnimation(Dog_State state) 
    {
        string animation_name = GetStateAnimationName(state);
        
        ani.Play(animation_name);
        
    }

    private string GetStateAnimationName(Dog_State state) 
    {
        switch(state) 
        {
            case Dog_State.idle:
                return "idle";
            case Dog_State.run:
                return "run";
            case Dog_State.attack:
                return "attack";
            case Dog_State.hited:
                return "hited";
            case Dog_State.died:
                return "died";
        }

        return "idle";
    }

    public void TakeDamage(int d) 
    {
        ChangeState(Dog_State.hited);
        health -= d;
        if(health <= 0)
        {
            gameObject.layer = 11; // un_attackable layer
            ani.Play("died");
            ChangeState(Dog_State.died);
        }
    }


    // if not idle state then do flip behavior
    private void FlipBehavior()
    {
        if(current_state == Dog_State.idle)
            return;
        float dir = Player.Instance.transform.position.x - transform.position.x;
        if(dir >= 0 && !face_right) 
            Flip();
        else if(dir < 0 && face_right)
            Flip();
    }


    private void Flip() 
    {
        face_right = !face_right;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // For Animator Call
    private void AttackForward()
    {
        float dir = Player.Instance.transform.position.x - transform.position.x;
        
        if(dir >= 0)
            rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
        else if(dir < 0)
            rb.AddForce(Vector2.left * 20, ForceMode2D.Impulse);
    }

    private void EndAttack() 
    {
        if(!Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
            ChangeState(Dog_State.run);
    }

    private void EndHitedState() 
    {
        // Run
        if(Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
        {
            ChangeState(Dog_State.run);
        }
        // Attack
        else if(Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
        {
            ChangeState(Dog_State.attack);
        }
        else
        {
            ChangeState(Dog_State.idle);
        }
    }

    private void OnDrawGizmos()
    {
        if(!DrawGizmos)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, find_player_radius);   

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack_radius);             
    }
}
