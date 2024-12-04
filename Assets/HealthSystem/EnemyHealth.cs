using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float currentHealth;

    private void OnEnable()
    {
        currentHealth = enemyHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //TakeDamage(10);
            
            currentHealth -= collision.gameObject.GetComponent<Bullet>().GetDamage();

            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
