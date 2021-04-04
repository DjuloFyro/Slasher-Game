using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask ennemiLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

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

        foreach(Collider2D ennemi in hitEnnemies)
        {
            ennemi.GetComponent<Ennemi>().TakeDamage(attackDamage);
        }
    }


    void OnDrawGizmosSelect()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
