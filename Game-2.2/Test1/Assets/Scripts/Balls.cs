using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StateColorBall
{
    Blue,
    Red,
    Green
}

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
    private string SceneName;

    private StateColorBall colorState;

    public SpriteRenderer graphics;







    void Start()
    {
        SceneName = "Map01";
        colorState = StateColorBall.Green;
        is_grounded = false;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }


    private void ChangeColorBall()
    {
        int randomiz = Random.Range(0, 2);

        if (colorState == StateColorBall.Green)
        {
            if(randomiz == 1)
            {
                BallTransformation("Blue");
            }
            else
            {
                BallTransformation("Red");
            }
        }

        if (colorState == StateColorBall.Blue)
        {
            if (randomiz == 1)
            {
                BallTransformation("Green");
            }
            else
            {
                BallTransformation("Red");
            }
        }

        if (colorState == StateColorBall.Red)
        {
            if (randomiz == 1)
            {
                BallTransformation("Blue");
            }
            else
            {
                BallTransformation("Green");
            }
        }

    }

    private void BallTransformation(string color)
    {
        if(color == "Green")
        {
            graphics.color = new Color(0f, 255f, 0f, 255f);
            SceneName = "Map01";
        }

        if (color == "Blue")
        {
            graphics.color = new Color(0f, 0f, 255f, 255f);
            SceneName = "Map02";
        }

        if (color == "Red")
        {
            graphics.color = new Color(255f, 0f, 0f, 255f);
            SceneName = "Map03";
        }
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
        ChangeColorBall();
    }
}
