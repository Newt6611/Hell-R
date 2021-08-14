using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBoss : MonoBehaviour, IEnemy
{
    [SerializeField] private bool draw_gizmos;

    public LayerMask PlayerLayer { get { return player_layer; } }
    public float FireBallRadius { get { return fireball_radius; } }
    public float SwingRadius { get { return swing_radius; } }
    public float SwingAttackRadius { get { return swing_attack_radius; } }
    public float CrackRadius { get { return crack_radius; } }
    public float Speed { get { return speed; } }

    public Transform mouse_pos;
    public Transform swing_pos;
    public Transform fireball_fly_pos;
    [HideInInspector] public Vector2 base_pos;

    [SerializeField] private float speed;
    [SerializeField] private LayerMask player_layer;
    [SerializeField] private float fireball_radius;
    [SerializeField] private float swing_radius;
    [SerializeField] private float swing_attack_radius;
    [SerializeField] private float crack_radius;

    public float RestTime { get { return rest_time; } }
    private float rest_time;


    private float full_health = 20;
    private float health;


    // Components
    public Rigidbody2D rigidbody { get; private set; }
    public Animator animator { get; private set;}

    private Dictionary<string, ISceneOneBoss> states;
    private ISceneOneBoss current_state;



    private void Start() 
    {
        health = full_health;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        
        states = new Dictionary<string, ISceneOneBoss>()
        {
            { "idle", new SceneOneBossIdle(this, "idle") },
            { "fireball", new SceneOneBossFireBall(this, "fireball") },
            { "swing", new SceneOneBossSwing(this, "swing") },
            { "crack", new SceneOneBossCrack(this, "crack") },
            { "roar", new SceneOneBossRoar(this, "roar") },
            { "walk", new SceneOneBossWalk(this, "walk") }
        };

        current_state = states["idle"];
        current_state.OnEnter();
        base_pos = transform.position;
        rest_time = 2;
    }

    private void Update()
    {
        current_state.OnUpdate();
        Debug.Log(current_state.GetName());
    }

    public void TakeDamage(int d)
    {
        health -= d;
        if(health <= 0)
            Debug.Log("Scene One Boss Dead !");
        UIManager.Instance.scene_one_boss_healthBar.fillAmount = (float)health / (float)full_health;
    }

    public void UpdateState(string name) 
    {
        current_state.OnExit();
        current_state = states[name];
        current_state.OnEnter();
    }

    public void PlayAnimation(string name)
    {
        animator.Play(name);
    }

    public void SetRestTime(float t) 
    {
        if(t < 1)
            rest_time = 1;
        rest_time = t;
    }

    private void OnDrawGizmos()
    {
        if(!draw_gizmos)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fireball_radius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, swing_radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(swing_pos.position, swing_attack_radius);

        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, crack_radius);
    }

    public void SetSpawner(SceneOneMonsterSpawner spawner) {}
    public void SetMode(bool is_dark) {}
}
