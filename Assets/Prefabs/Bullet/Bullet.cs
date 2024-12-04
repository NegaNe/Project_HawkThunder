using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody rb;

    public float damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();
            Collider bulletCollider = GetComponent<Collider>();

            if (playerCollider != null && bulletCollider != null)
            {
                Physics.IgnoreCollision(bulletCollider, playerCollider);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }

    public float GetDamage()
    {
        return damage;
    }

}
