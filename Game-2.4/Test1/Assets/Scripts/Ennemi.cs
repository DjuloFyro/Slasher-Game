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
    private GameObject target;

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

    //Deplacement
    [SerializeField]
    private GameObject groundCheckEnnemi;

    private bool grounded;

    public bool Grounded { get { return grounded; } }

    private bool running;

    public bool Running { get { return running; } }

    private float dir;

    //CombatEnnemi
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    public GameObject objectToDestroy;
    private float animDeathLenght = 1.5f;

    ///KnockBack
    [SerializeField]
    private float knockbackSpeedX, knockbackSpeedY, knockbackDuration;

    [SerializeField]
    private bool applyKnockback;

    private float knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback;


    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
        {
            Debug.LogError("No player found");


        }

        
        target = GameManager.Instance.PlayerInstanciate;

        //To not destroy when changing scene
        DontDestroyOnLoad(target);


        /*if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveSpecificFromDontDestroyOnLoad(target);
        }*/

        






        currentHealth = maxHealth;

        

        //StartCoroutine(UpdatePath());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }

        StartCoroutine(KnockBack());
    }

    private IEnumerator Die()
    {
        
        animator.SetBool("IsDead",true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //Score
        Inventory.instance.AddScore(1);
        yield return new WaitForSeconds(animDeathLenght);
        Destroy(gameObject);
    }

    public IEnumerator KnockBack()
    {
        float timer = 0;

        if (target != null)
        {
            while (knockbackDuration > timer)
            {
                timer += Time.deltaTime;
                Vector2 knockdir = (target.transform.position - transform.position).normalized;
                rb.AddForce(-knockdir * 20);

            }
        }

        yield return 0;
    }

    private void MoveEnnemi()
    {

        if (target != null)
        {


            grounded = Physics2D.OverlapCircle(groundCheckEnnemi.transform.position, radiusCircleEnnemi, layerEnnemi);


            dir = target.transform.position.x - transform.position.x;
            Vector2 direction = new Vector2(dir, 0);
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            running = true;

            if (target.transform.position.x > transform.position.x)
            {

                GetComponent<SpriteRenderer>().flipX = true;

            }
            else
            {

                GetComponent<SpriteRenderer>().flipX = false;

            }
        }

        
    }

    //Deal damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health h = collision.transform.GetComponent<Health>();
            h.TakeDamage(1);
            collision.gameObject.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);

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
