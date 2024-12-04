using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float Speed;
    private float AddPwr = 1;
    public TMP_Text PwrUpText;
    public enum PowerUpType { 
        IncreasePwr,
        DecreasePwr
    }
    public PowerUpType powerUpType;
    [SerializeField] float maxPower;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        int selection = Random.Range(1, 3);

        switch (selection)
        {
            case 1:
            powerUpType = PowerUpType.IncreasePwr;
            PwrUpText.text =  AddPwr.ToString() +" Power"; 
            renderer.material.color = Color.blue;
            break;
            case 2:
            powerUpType = PowerUpType.DecreasePwr;
            renderer.material.color = Color.red;
            AddPwr = -AddPwr;
            PwrUpText.text =  AddPwr.ToString() +" Power";

            break;
            default:
            powerUpType = PowerUpType.IncreasePwr; 
            break;
        }
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.back * 4 * Time.fixedDeltaTime);
        
    }

    // Update is called once per frame

    private void IncreasePower()
    {
        AddPwr += 1;
        PwrUpText.text =  AddPwr.ToString() +" Power";
    }
    private void DecreasePower()
    {
        AddPwr -= 1;
        PwrUpText.text =  AddPwr.ToString() +" Power";
    }

    private void OnTriggerEnter(Collider other) 
    {

        if(other.gameObject.CompareTag("Bullet"))
        {
            if(powerUpType == PowerUpType.IncreasePwr)
            {
                IncreasePower();
            }
            else if(powerUpType == PowerUpType.DecreasePwr)
            {
                DecreasePower();
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            // konekin ke player buat nambah powerup (dmg)

            PlayerShoot playerShoot = other.GetComponent<PlayerShoot>();

            playerShoot.bulletDamage += AddPwr;

            if (playerShoot.bulletDamage >= maxPower)
            {
                playerShoot.bulletDamage = maxPower;
            }

            if (playerShoot.bulletDamage <= 0)
            {
                playerShoot.bulletDamage = 1;
            }

            playerShoot.damageText.text = "Damage : " + playerShoot.bulletDamage.ToString();

            gameObject.SetActive(false);
        }

    }

    private void OnDisable()
    {
        AddPwr = 1;
        PwrUpText.text = AddPwr.ToString() + " Power";
    }
}
