using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int duration = 4;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DisableObject(duration));
    }

    private IEnumerator DisableObject(int duration)
    {
        yield return new WaitForSeconds(duration);

        gameObject.SetActive(false);
    }
}
