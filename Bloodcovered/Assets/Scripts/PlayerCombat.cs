using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 6f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        //play an attack animation
        animator.SetTrigger("Attack");

        //detect enemies in range
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //if (hitEnemies[0] != null)
        //{
        //    animator.SetTrigger("Hit");
        //}

        //kill them
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("hit enemy " + enemy.name);
            //Debug.Log(enemy.col);
            enemy.GetComponent<EnemyController>().Death();
            animator.SetInteger("Hit", animator.GetInteger("Hit") + 1);
            Debug.Log("shes a maniac maniac oh no no");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
