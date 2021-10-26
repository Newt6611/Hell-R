using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static Player m_instance;
    public static Player Instance { get { return m_instance; } }
    public LayerMask player_layer;

    public bool draw_gizmos;

    // Prepos For Scene Transition ( in same scene )
    public Transform pre_pos;

    // Player Health
    public int TotalHealth;
    private int current_health;
    public int Current_Health { get { return current_health;} }

    // Player Speed Property
    private float speed;
    public float Speed { get { return speed; } }

    [SerializeField] private float normal_speed;
    public float Normal_Speed { get { return normal_speed; } }
    [SerializeField] private float slow_speed; // For like defend state
    public float SlowSpeed{ get { return slow_speed; } }

    // Player Jump And Movement Property
    [SerializeField] private float jump_force;
    public float Jump_Force { get { return jump_force; } }

    private Vector2 movement;
    public Vector2 Movement { get { return movement; } }

    private bool face_right = true;

    public bool Jumping { get; set;} 
    public bool Attacking { get; set; }
    public bool Defending { get; set; }

    private M_Input player_input;

    private IPlayerState current_state;


    //// jump
    [Header("Jump Property")]
    public Transform jump_dectector;
    public float jump_dectector_radius;
    public LayerMask ground_layer;

    //// attack
    [Header("Attack Property")]
    public Transform attack_dectector;
    public float attack_dectector_radius;
    public LayerMask attackable_layer;

    private Light2D light;

    //
    [SerializeField] private PhysicsMaterial2D no_friction;
    [SerializeField] private PhysicsMaterial2D friction;


    // Components
    [SerializeField] private InputReader input_reader;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator ani;
    [HideInInspector] public GameFeel game_feel;
    [HideInInspector] public SpriteRenderer sprite_renderer;
    
    public Dictionary<string, IPlayerState> state_cache;
    

    public event Action player_into_door_use_keyboard;
    public event Action player_pick_item;


    [Header("Sound Clips")]
    [HideInInspector] public AudioSource audio_source;
    public AudioClip walk;
    public AudioClip[] hit;
    public AudioClip attack;
    public AudioClip jump;
    

    private void Awake() 
    {
        input_reader.Enable();
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        player_input = new M_Input();
        speed = normal_speed;
    }

    private void OnEnable()
    {
        Enable();   
    }

    private void OnDisable()
    {
        Disable();
    }

    public void Enable() 
    {
        input_reader.movementEvent += PlayerMoveAction;
        input_reader.jumpEvent += JumpAction;
        input_reader.attackEvent += AttackAction;
        input_reader.defendEvent += DefendAction;
        input_reader.defendKeyUpEvent += DefendKeyUp;
        input_reader.intoDoorEvent += IntoDoorAction;
        input_reader.getItemEvent += PickItem;
    }

    public void Disable() 
    {
        input_reader.movementEvent -= PlayerMoveAction;
        input_reader.jumpEvent -= JumpAction;
        input_reader.attackEvent -= AttackAction;
        input_reader.defendEvent -= DefendAction;
        input_reader.defendKeyUpEvent -= DefendKeyUp;
        input_reader.intoDoorEvent -= IntoDoorAction;
        input_reader.getItemEvent -= PickItem;
    }

    private void Start() 
    {
        SetUpSceneData();
        //SceneOneManager.Instance.on_normal_mode += OnNormalMode;
        //SceneOneManager.Instance.on_dark_mode += OnDarkMode;
        light = GetComponentInChildren<Light2D>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        game_feel = GetComponent<GameFeel>();
        audio_source = GetComponent<AudioSource>();

        state_cache = new Dictionary<string, IPlayerState>()
        {
            { "idle", new IdleState("idle", this) },
            { "run", new RunState("run", this) },
            { "attack", new AttackState("attack", this) },
            { "jump", new JumpState("jump", this) },
            { "defend", new DefendState("defend", this) },
            { "hited", new HitedState("hited", this) }
        };

        current_health = TotalHealth;
        current_state = state_cache["idle"];
        current_state.OnStateEnter();
    }

    

    private void Update()
    {
        current_state.OnUpdate();

        //Debug.Log(current_state.GetStateName());
        
        // Handle Sprite Flip
        if(movement.x > 0 && !face_right)
            Flip();
        else if(movement.x < 0 && face_right)
            Flip();
    }

    private void FixedUpdate()
    {
        current_state.OnFixedUpdate();
        UpdatePhysicsMaterial();
    }

    private void LateUpdate() 
    {
        current_state.OnLateUpdate();
    }




    // Input Call Backs
    private void PlayerMoveAction(Vector2 m)
    {
        movement = m;
        if(Mathf.Abs(movement.x) != 0 && !Jumping && !Attacking && !Defending)
            UpdateState("run");
    }

    private void JumpAction()
    {
        if(Physics2D.OverlapCircle(jump_dectector.position, jump_dectector_radius, ground_layer))
            UpdateState("jump");
    }

    private void AttackAction() 
    {
        if(!Attacking)
        {
            if(UIManager.Instance.StaminaBar.fillAmount <= 0.15f)
                return;
            UIManager.Instance.ReduceStamina(0.25f);
            UpdateState("attack");
        }
    }

    private void DefendAction()
    {
        UpdateState("defend");
    }

    private void DefendKeyUp()
    {
        if(movement.x != 0)
            UpdateState("run");
        else
            UpdateState("idle");
    }

    private void IntoDoorAction()
    {
        player_into_door_use_keyboard?.Invoke();
    }

    private void PickItem() 
    {
        player_pick_item?.Invoke();
    }

    ///////////////////////////////////////
    
    public void TakeDamage(Transform target, int d)
    {
        current_health -= d;
        UpdateState("hited");
        Invoke("ResetMaterial", 0.1f);
        float dir = target.position.x - transform.position.x;
        float currentX = transform.position.x;

        if(dir >= 0 && !face_right)
            Flip();
        else if(dir < 0 && face_right)
            Flip();


        if(dir >= 0)
            currentX -= 3f;
        else    
            currentX += 3f;

        transform.position = new Vector2(currentX, transform.position.y);
    }

    public void Flip()
    {
        face_right = !face_right;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Move() 
    {
        Vector2 vel = rb.velocity;
        vel.x = Speed * Movement.x * Time.fixedDeltaTime; 
        rb.velocity = vel;
    }

    public void StartMove()
    {
        speed = normal_speed;
    }

    public void StopMove()
    {
        speed = slow_speed;
    }

    public void UpdateState(string state_name)
    {
        if(state_name == current_state.GetStateName())
            return;

        current_state.OnStateExit();
        current_state = state_cache[state_name];
        current_state.OnStateEnter();
    }

    private void ResetMaterial()
    {
        sprite_renderer.color = Color.white;
    }



    private void UpdatePhysicsMaterial()
    {
        if(Movement.x == 0 && rb.sharedMaterial != friction)
            rb.sharedMaterial = friction;
        else if(Movement.x != 0 && rb.sharedMaterial != no_friction)
            rb.sharedMaterial = no_friction;
    }

    // For Animator Call
    private void Attack() 
    {
        Collider2D e = Physics2D.OverlapCircle(attack_dectector.position, attack_dectector_radius, attackable_layer); 
        if(e != null)
        {
            game_feel.StopScreen(0.1f);
            game_feel.ShakeCamera(5, 0.2f);
            e.GetComponent<IEnemy>().TakeDamage(1);
            AudioManager.Instance.PlayOneShot(hit[UnityEngine.Random.Range(0, hit.Length)], 0.5f);
        }
    }
    
    private void EndAttack()
    {
        if(movement.x == 0)
            UpdateState("idle");
        else if(movement.x != 0)
            UpdateState("run");
    }

    ////////////////////////////////////////////////
    private void SetUpSceneData()
    {
        if(GameManager.Instance.CurrentScene == SceneName.SceneOne)
        {
            SceneOneManager.Instance.on_normal_mode += OnNormalMode;
            SceneOneManager.Instance.on_dark_mode += OnDarkMode;
        }
    }

    // scene one
    private void OnNormalMode()
    {
        //0.8
        light.intensity = 0.5f;
    }

    private void OnDarkMode()
    {
        //0.5
        light.intensity = 1f;
    }

    private void OnDrawGizmos()
    {
        if(!draw_gizmos)
            return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(jump_dectector.position, jump_dectector_radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attack_dectector.position, attack_dectector_radius);
    }
}
