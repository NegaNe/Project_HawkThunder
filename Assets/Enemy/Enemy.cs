using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    float speed;

    private void Update()
    {
        
        transform.Translate(Vector3.back * Random.Range(2, 8) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);
    }


}
