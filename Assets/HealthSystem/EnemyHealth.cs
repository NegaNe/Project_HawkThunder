using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 50;
    public int enemyCurrentHealth;

    private void OnEnable()
    {
        enemyCurrentHealth = enemyHealth;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(10); 
            
            if (enemyCurrentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        
    }

    public void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
    }
}
