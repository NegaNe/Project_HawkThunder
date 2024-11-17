using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EnemyScript : MonoBehaviour
{
  public float Health;
  public float Damage;
  public float Speed;
  
  public void ResetObject()
  {
    Health = 100;
  }
  void OnDisable()
  {
    ObjectPooling.objectPooling.ReturnToPool(gameObject);
  }

}
