using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public int currentPlayerHealth;

    public TMP_Text healthText;
    private void Start()
    {
        Inizialize();
    }

    public void Inizialize()
    {
        currentPlayerHealth = playerHealth;
        healthText.text = "HP :" + currentPlayerHealth.ToString();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            TakeDamage(30);
        }
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;

        healthText.text = "HP :" + currentPlayerHealth.ToString();
    }
}
