using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health = 100f;
    Animator anim;
    NavMeshAgent nav;
    public int scoreValue = 100;
    CapsuleCollider kol;
 

    private void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        kol = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            ScoreManager.score += scoreValue;
            kol.enabled = false;
        }
    }

     void Die()
    {
        nav.isStopped = true;
        anim.SetBool("IsDead", true);
        Destroy(gameObject,3);
        
    }
}
