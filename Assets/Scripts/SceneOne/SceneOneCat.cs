using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Cat_State 
{
    idle, run, attack, hited, died    
}

public class SceneOneCat : MonoBehaviour, IEnemy
{
    [SerializeField] Canvas health_bar_obj;
    [SerializeField] private Image health_bar;
    [SerializeField] bool DrawGizmos;
    [SerializeField] private float find_player_radius;
    [SerializeField] private float attack_radius;

    [SerializeField] private Transform attack_pos;
    [SerializeField] float attack_pos_radius;

    [SerializeField] private float speed;

    private bool face_right = true;

    [SerializeField] private int total_health;
    private int current_health;

    private Cat_State current_state;

    // Components
    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer sprite_renderer;

    private void Start()
    {
        SceneOneManager.Instance.RegistDarkObj(this.gameObject);
        if(SceneOneManager.Instance.Mode == SceneOneMode.normal)
            gameObject.SetActive(false);

        current_state = Cat_State.idle;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        ani.Play("idle");
        current_health = total_health;
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
            case Cat_State.idle:
                IdleState();
                break;
            case Cat_State.run:
                RunState();
                break;
            case Cat_State.attack:
                AttackState();
                break;
            case Cat_State.hited:
                HitedState();
                break;
            case Cat_State.died:
                DiedState();
                break;
        }    
    }


    private void IdleState() 
    {
        // find player is in area to chase
        if(Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
        {
            ChangeState(Cat_State.run);
        }
    }

    private void RunState()
    {
        if(Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
            ChangeState(Cat_State.attack);

        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, speed * Time.fixedDeltaTime);

        // if too far, then back to idle state
        if(!Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
            ChangeState(Cat_State.idle);
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

    private void ChangeState(Cat_State next_state) 
    {
        if(current_state == next_state)
            return;

        current_state = next_state;
        PlayeAnimation(next_state);
    }

    private void PlayeAnimation(Cat_State state) 
    {
        string animation_name = GetStateAnimationName(state);
        
        ani.Play(animation_name);
        
    }

    private string GetStateAnimationName(Cat_State state) 
    {
        switch(state) 
        {
            case Cat_State.idle:
                return "idle";
            case Cat_State.run:
                return "run";
            case Cat_State.attack:
                return "attack";
            case Cat_State.hited:
                return "hited";
            case Cat_State.died:
                return "died";
        }

        return "idle";
    }

    public void TakeDamage(int d) 
    {
        ChangeState(Cat_State.hited);
        sprite_renderer.color = Color.red;
        Invoke("ResetMaterial", 0.1f);

        current_health -= d;
        health_bar.fillAmount = (float)current_health / (float)total_health;
        if(current_health <= 0)
        {
            health_bar_obj.gameObject.SetActive(false);
            gameObject.layer = 11; // un_attackable layer
            ani.Play("died");
            ChangeState(Cat_State.died);
        }
    }

    private void ResetMaterial()
    {
        sprite_renderer.color = Color.white;
    }




    // if not idle state then do flip behavior
    private void FlipBehavior()
    {
        if(current_state == Cat_State.idle || current_health <= 0)
            return;
        float dir = Player.Instance.transform.position.x - transform.position.x;
        if(dir >= 0 && !face_right) {
            health_bar.fillOrigin = 0;
            Flip();
        }
        else if(dir < 0 && face_right) {
            health_bar.fillOrigin = 1;
            Flip();
        }
    }


    private void Flip() 
    {
        face_right = !face_right;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // For Animator Call
    private void Attack()
    {
        if(Physics2D.OverlapCircle(attack_pos.position, attack_pos_radius, Player.Instance.player_layer))
        {
            Player.Instance.TakeDamage(transform, 1);
        }
    }

    private void EndAttack() 
    {
        if(!Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
            ChangeState(Cat_State.run);
    }

    private void EndHitedState() 
    {
        // Run
        if(Physics2D.OverlapCircle(transform.position, find_player_radius, Player.Instance.player_layer))
        {
            ChangeState(Cat_State.run);
        }
        // Attack
        else if(Physics2D.OverlapCircle(transform.position, attack_radius, Player.Instance.player_layer))
        {
            ChangeState(Cat_State.attack);
        }
        else
        {
            ChangeState(Cat_State.idle);
        }
    }

    
    //
    private void OnDestroy() 
    {
        SceneOneManager.Instance.RemoveDarkObj(gameObject);
    }

    private void OnDrawGizmos()
    {
        if(!DrawGizmos)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, find_player_radius);   

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack_radius);        

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attack_pos.position, attack_pos_radius);        
    }
}
