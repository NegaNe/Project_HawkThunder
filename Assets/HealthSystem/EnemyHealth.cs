using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    
    public TMP_Text HPText;

    private void OnEnable()
    {
        enemyHealth = EnemySpawner.givenEnemyHealth;

        HPText.text = enemyHealth.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //TakeDamage(10);

            enemyHealth -= collision.gameObject.GetComponent<Bullet>().GetDamage();

            HPUpdate();

            if (enemyHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void HPUpdate()
    {
        HPText.text = enemyHealth.ToString();
    }

}
