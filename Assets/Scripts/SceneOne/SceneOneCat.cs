using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum Cat_State 
{
    idle, run, attack, hited, died, none 
}

public class SceneOneCat : MonoBehaviour, IEnemy
{
    //[SerializeField] Canvas health_bar_obj;
    //[SerializeField] private Image health_bar;
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

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D light;

    [SerializeField] private GameObject purple_particle_pre;
    private GameObject purplr_particle = null;

    private Material dissolve_material;
    [SerializeField][Range(0,1)]
    private float dissolve_value;

    // Components
    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer sprite_renderer;
    private TrailRenderer trail_renderer;

    private SceneOneMonsterSpawner spawner;
    private bool particl_start_moving = false;
    private bool is_dark;

    private void Start()
    {
        current_state = Cat_State.none;
        rb = GetComponent<Rigidbody2D>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        current_health = total_health;

        dissolve_value = 1;
        dissolve_material = GetComponent<SpriteRenderer>().material;
    }

    public void SetSpawner(SceneOneMonsterSpawner spawner) => this.spawner = spawner;

    public void SetMode(bool is_dark) => this.is_dark = is_dark;

    private void Update() 
    {
        // if not idle state then do flip behavior;
        FlipBehavior();

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

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 3.0f));
        
        // checking distant if too far then delete
        if(is_dark && SceneOneManager.Instance.Mode == SceneOneMode.dark)
            CheckDistance();
        else if(!is_dark && SceneOneManager.Instance.Mode == SceneOneMode.normal)
            CheckDistance();

        if(trail_renderer == null)
            trail_renderer = GetComponentInChildren<TrailRenderer>();
        if(ani == null)
            ani = GetComponent<Animator>();
        trail_renderer.enabled = true;

        if(is_dark)
            light.enabled = true;
        else
            light.enabled = false;
        current_state = Cat_State.none;
        trail_renderer.enabled = true;
        ani.Play("spawn");
    }

    private void CheckDistance()
    {
        if(Vector2.Distance(Player.Instance.transform.position, transform.position) > 15)
        {
            if(is_dark)
                SceneOneManager.Instance.RemoveDarkObj(gameObject);
            else
                SceneOneManager.Instance.RemoveNormalObj(gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnEnable() 
    {   
        StartCoroutine(Delay());
    }

    private void OnDisable()
    {
        sprite_renderer.enabled = false;
        //health_bar_obj.gameObject.SetActive(false);
        current_state = Cat_State.none;
    }

    private void Spawn() 
    {
        trail_renderer.enabled = false;
        //health_bar_obj.gameObject.SetActive(true);
        
        sprite_renderer.enabled = true;
        current_state = Cat_State.idle;
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
        dissolve_material.SetFloat("_Fade", dissolve_value);
        StartCoroutine(DiedDelay(5));
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
        //health_bar.fillAmount = (float)current_health / (float)total_health;
        if(current_health <= 0)
        {
            //health_bar_obj.gameObject.SetActive(false);
            gameObject.layer = 11; // un_attackable layer
            ani.Play("died");
            ChangeState(Cat_State.died);

            // Show Purple Particle
            particl_start_moving = true;
            purplr_particle = Instantiate(purple_particle_pre, transform.position, Quaternion.identity);

            if(is_dark)
                SceneOneManager.Instance.RemoveDarkObj(gameObject);
            else
                SceneOneManager.Instance.RemoveNormalObj(gameObject);
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
            //health_bar.fillOrigin = 0;
            Flip();
        }
        else if(dir < 0 && face_right) {
            //health_bar.fillOrigin = 1;
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
