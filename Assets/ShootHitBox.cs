using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHitBox : MonoBehaviour
{
    // Start is called before the first frame update
void OnTriggerEnter(Collider other)
{
    other.gameObject.SetActive(false);
}
}
