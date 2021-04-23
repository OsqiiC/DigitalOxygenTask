using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    [SerializeField] private float deathDelay = 0f;

    private Animator _animator;

    private void Start()
    {
        isDead = false;
        _animator = GetComponent<Animator>();
    }

    public void DeathInput()
    {
        isDead = true;

        _animator.SetTrigger("Death");
        // Perform enemy death after death animation
        DelayedExecute.instance.ExecuteMethod(PerformDeath, deathDelay);
    }

    private void PerformDeath()
    {
        EnemySpawner.instance.enemyCounter--;
        
        if (gameObject !=null) Destroy(gameObject);

        if (EnemySpawner.instance.enemyCounter < 1)
        {
            UIExitOrRestart.instance.ActivateButtons();
        }
    }
}
