using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerController))]


public class PlayerMovement : MonoBehaviour
{

    /* public float moveSpeed;
     public float jump_force;

     private bool is_jumping;
     private bool is_grounding;

     public Transform GroundCheckLeft;
     public Transform GroundCheckRight;


     public Rigidbody2D rb;
     private Vector3 velocity = Vector3.zero;

    /* private Transform playerInstanciate;

     public Transform PlayerInstanciate { get { return playerInstanciate; } }*/

    public Vector2 velocity;
    public Rigidbody2D rb;

    [SerializeField] private float maxSpeed, maxSpeedJump, radiusCircle;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private LayerMask layer;

    private bool grounded;
    public bool Grounded { get { return grounded; } }

    //Dash variables
    public float DashForce;
    public float StartDashTimer;
    float CurrentDashTimer;
    float DashDirection;
    bool isDashing;
    float movX;

    public CapsuleCollider2D playerCollider;


    public AudioSource audioSource;
    public AudioClip sound;



    public static PlayerMovement instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("trop d'instance samer");
            return;
        }
        instance = this;
    }
    



    void Start()
    {
        //anim = GetComponent<Animator>();
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift) && movX != 0)
        {
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            rb.velocity = Vector2.zero;
            DashDirection = movX;
        }
    }

    void Dash()
    {
        if (isDashing)
        {
            rb.velocity = new Vector2(1 * DashForce * DashDirection, rb.velocity.y);

            

            CurrentDashTimer -= Time.deltaTime;

            if (CurrentDashTimer <= 0)
            {
                audioSource.PlayOneShot(sound);
                isDashing = false;
            }
        }

        if (!isDashing)
        {
            PerformRunAndJump();
        }
    }

    void FixedUpdate()
    {


        Dash();
        /*is_grounding = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);

        float horizontal_movement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        if(Input.GetButtonDown("Jump") && is_grounding == true)
        {
            is_jumping = true;
        }

        MovePlayer(horizontal_movement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(is_jumping == true)
        {
            rb.AddForce(new Vector2(0f, jump_force));
            is_jumping = false;
        }*/
    } 



    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformRunAndJump()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.transform.position,radiusCircle, layer);
        if(grounded)
        {
            rb.AddForce(new Vector2(0f, velocity.y) * Time.deltaTime * maxSpeedJump, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime, rb.velocity.y);

       
    }
}
