using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask ennemiLayers;
    public LayerMask ballsLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public AudioSource audioSource;
    
    public AudioClip[] soundplaylist;

    public static PlayerCombat instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance de combat player samer");
            return;
        }
        instance = this;
    }


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }


    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnnemies =Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemiLayers);

        Collider2D[] hitBalls = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ballsLayers);


        int randomiz = Random.Range(0, 4);
        audioSource.PlayOneShot(soundplaylist[randomiz]);

        foreach (Collider2D ennemi in hitEnnemies)
        {
            
            ennemi.GetComponent<Ennemi>().TakeDamage(attackDamage);
        }

        foreach (Collider2D ball in hitBalls)
        {
            
            ball.GetComponent<Balls>().TakeDamage(5);
        }
    }


    void OnDrawGizmosSelect()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
