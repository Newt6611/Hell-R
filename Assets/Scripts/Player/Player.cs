using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private static Player m_instance;
    public static Player Instance { get { return m_instance; } }
    public LayerMask player_layer;

    public bool draw_gizmos;

    [SerializeField] private float speed;
    public float Speed { get { return speed; } }

    [SerializeField] private float jump_force;
    public float Jump_Force { get { return jump_force; } }

    private Vector2 movement;
    public Vector2 Movement { get { return movement; } }

    private bool face_right = true;
    public bool Can_Jump { get; set; }
    public bool Jumping { get; set;} 

    public bool Attacking { get; set; }


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



    // Components
    [SerializeField] private InputReader input_reader;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator ani;
    [HideInInspector] public GameFeel game_feel;
    
    private Dictionary<string, IPlayerState> state_cache;
    
    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        player_input = new M_Input();
    }

    private void OnEnable()
    {
        input_reader.movementEvent += PlayerMoveAction;
        input_reader.jumpEvent += JumpAction;
        input_reader.attackEvent += AttackAction;
    }

    private void OnDisable()
    {
        input_reader.movementEvent -= PlayerMoveAction;
        input_reader.jumpEvent -= JumpAction;
        input_reader.attackEvent -= AttackAction;
    }

    private void Start() 
    {
        Can_Jump = true;

        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        game_feel = GetComponent<GameFeel>();
        
        state_cache = new Dictionary<string, IPlayerState>()
        {
            { "idle", new IdleState("idle", this) },
            { "run", new RunState("run", this) },
            { "attack", new AttackState("attack", this) },
            { "jump", new JumpState("jump", this) }
        };

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
    }

    private void LateUpdate() 
    {
        current_state.OnLateUpdate();
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {

    }



    // Input Call Backs
    private void PlayerMoveAction(Vector2 m)
    {
        movement = m;
        if(Mathf.Abs(movement.x) != 0 && !Jumping && !Attacking)
            UpdateState("run");
    }

    private void JumpAction()
    {
        if(Can_Jump)
            UpdateState("jump");
    }

    private void AttackAction() 
    {
        if(!Attacking)
            UpdateState("attack");
    }

    ///////////////////////////////////////
    

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

    public void UpdateState(string state_name)
    {
        if(state_name == current_state.GetStateName())
            return;

        current_state.OnStateExit();
        current_state = state_cache[state_name];
        current_state.OnStateEnter();
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
