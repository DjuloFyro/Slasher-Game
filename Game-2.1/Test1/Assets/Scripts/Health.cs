using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 5;
    public int numOfHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool Is_invincible = false;
    public float invincibilityFlashDelay = 0.2f;
    public float invincibilityTimeAfterHit = 2f;
    public SpriteRenderer graphics;


    public bool is_dead;

    public static Health instance;

   




    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance Health samer");
            return;
        }
        instance = this;

    }


    private void Start()
    {
        
    }

    public void HealthAnim()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        if (!Is_invincible)
        {
            health -= damage;


            if(health <= 0)
            {
                Die();
                return;
            }

            Is_invincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        is_dead = true;
        PlayerMovement.instance.enabled = false;
        PlayerCombat.instance.enabled = false;
        AnimationController.instance.anim.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        Destroy(gameObject);

    }

    public void Respawn()
    {

         

         PlayerMovement.instance.enabled = true;
         PlayerCombat.instance.enabled = true;
         //AnimationController.instance.anim.SetTrigger("Respawn");
         PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;

         PlayerMovement.instance.playerCollider.enabled = true;
         health = numOfHearts;


       

    }

    void Update()
    {
        
        HealthAnim();
    }


    public IEnumerator InvincibilityFlash()
    {
        while(Is_invincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        Is_invincible = false;
    }

   
}
