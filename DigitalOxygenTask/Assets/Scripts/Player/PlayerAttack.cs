using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackDelay = 0;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        AttackInput();
    }

    private void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            // Perform attack after pressing attack button with some delay
            DelayedExecute.instance.ExecuteMethod(PerformAttack,attackDelay);
        }     
    }

    private void PerformAttack()
    {
        // Getting collider in attack area
        Collider2D attackedCollider = Physics2D.OverlapCircle(transform.position, attackRadius);

        // If its enemy, finish him
        if (attackedCollider.GetComponent<Enemy>() != null)
        {
            Enemy currentEnemy = attackedCollider.GetComponent<Enemy>();

            if (!currentEnemy.isDead) currentEnemy.DeathInput();
        }
    }

    private void OnDrawGizmos()
    {
        // Shows attack area in editor
        Gizmos.DrawWireSphere(transform.position,attackRadius);
    }
}
