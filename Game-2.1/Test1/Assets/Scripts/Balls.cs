using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balls : MonoBehaviour
{
    public GameObject groundCheckBall;
    private bool is_grounded;
    private Rigidbody2D rb;
    [SerializeField] private float radiusCircleBall;

    [SerializeField]
    private LayerMask layerBall;

    private int maxHealth = 20;
    private int currentHealth;


    //Scene
    public string SceneName;
   


    



    void Start()
    {
       
        is_grounded = false;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void OnGroundFreeze()
    {
        is_grounded = Physics2D.OverlapCircle(groundCheckBall.transform.position, radiusCircleBall, layerBall);

        if(is_grounded)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    private void Die()
    {

        //animator.SetBool("IsDead", true);

        //yield return new WaitForSeconds(animDeathLenght);
        
        Destroy(gameObject);
        SceneManager.LoadScene(SceneName);
    }

    void Update()
    {
        OnGroundFreeze();
    }
}
