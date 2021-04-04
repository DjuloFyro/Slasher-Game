using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]




public class Ennemi : MonoBehaviour
{




    //PREMIER TEST PATHFINDING ENNEMY A GARDER
    

    [SerializeField]
    private Transform target;

    /*[SerializeField]
    private float updateRate = 2f;*/

    [SerializeField]
    private Path path;

    [SerializeField]
    private float speed;

    [SerializeField]
    private ForceMode2D fMode;

    [SerializeField]
    public float nextWaypointDistance;

    private Seeker seeker;

    private bool pathIsEnded;

    private int CurrentWaypoint;

    private Rigidbody2D rb;

    

    [SerializeField]
    private LayerMask layerEnnemi;

    [SerializeField] private float radiusCircleEnnemi;


    [SerializeField]
    private GameObject groundCheckEnnemi;

    private bool grounded;

    public bool Grounded { get { return grounded; } }

    private bool running;

    public bool Running { get { return running; } }

    //CombatEnnemi
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;










    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        target = GameManager.Instance.PlayerInstanciate;

        currentHealth = maxHealth;

        if(target == null)
        {
            Debug.LogError("No player found");
        }

        //StartCoroutine(UpdatePath());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        animator.SetBool("IsDead",true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

    }

    private void MoveEnnemi()
    {
        grounded = Physics2D.OverlapCircle(groundCheckEnnemi.transform.position, radiusCircleEnnemi, layerEnnemi);

        if (target.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            running = true;
            rb.AddForce(new Vector2(1f, 0));
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            running = true;
            rb.AddForce(new Vector2(-1f, 0));
        }

        if(target.position.y < transform.position.y && ! grounded )
        {
           
            rb.AddForce(new Vector2(1f, 0));
        }
    }

    //Deal damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            Health h = collision.transform.GetComponent<Health>();
            h.TakeDamage(1);


        }
    }

    private void Update()
    {
       
        MoveEnnemi();
    }


    /*

    public IEnumerator UpdatePath()
    {

        if(target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);

            yield return new WaitForSeconds(1f / updateRate);
            StartCoroutine(UpdatePath());
           
        }
    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            CurrentWaypoint = 0;
        }
    }
   
    public void FixedUpdate()
    {

        


        if (target == null)
            {
                if (GameManager.Instance.PlayerInstanciate != null)
                {
                
                    target = GameManager.Instance.PlayerInstanciate;
                    StartCoroutine(UpdatePath());
                }
                return;
            }

            if (path == null)
            {
                return;
            }

            
            if (CurrentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                {
                    return;
                }

                pathIsEnded = true;
                return;
            }

            pathIsEnded = false;

            float dir = path.vectorPath[CurrentWaypoint].x - rb.position.x;
            //Debug.Log("direction: " + dir);
            




            dir *= speed * Time.fixedDeltaTime;
            

            rb.AddForce(new Vector3(dir,0f), fMode);

            float dist = Vector3.Distance(transform.position, path.vectorPath[CurrentWaypoint]);

            

        if (dist < nextWaypointDistance)
            {
                CurrentWaypoint++;
                return;
            }

        
    }*/
}
