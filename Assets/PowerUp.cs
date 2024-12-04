using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float AddPwr = 1;
    public TMP_Text PwrUpText;
    public enum PowerUpType { 
        IncreasePwr,
        DecreasePwr
    }
    public PowerUpType powerUpType;
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

    // Update is called once per frame
    void Update()
    {
        IncreasePower();
        DecreasePower();
    }

    private void IncreasePower()
    {

    }
    private void DecreasePower()
    {
            PwrUpText.text =  AddPwr.ToString() +" Power";
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            
        }

        if(other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
