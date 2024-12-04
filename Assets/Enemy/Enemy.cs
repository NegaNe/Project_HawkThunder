using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    float speed;

    private void FixedUpdate()
    {
        
        transform.Translate(Vector3.back * 4 * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
    if( other.gameObject.tag == "Player" || other.gameObject.tag == "Killer")
        gameObject.SetActive(false);
    }


}
