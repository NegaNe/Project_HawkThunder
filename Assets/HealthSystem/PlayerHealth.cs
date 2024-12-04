using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public int currentPlayerHealth;

    private void Start()
    {
        Inizialize();
    }

    public void Inizialize()
    {
        currentPlayerHealth = playerHealth;
    }

    [ContextMenu("Player Damage")]
    private void TesterDamage()
    {
        if (playerHealth < 0)
        {
            return;
        }

        TakeDamage(10);

        if(playerHealth < 10)
        {
            playerHealth = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }
}
