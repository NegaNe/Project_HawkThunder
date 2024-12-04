using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Bullet;
    float ShootDelay = 0.1f;
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 0f, ShootDelay);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Bullet.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20, ForceMode.Impulse);
        Destroy(bullet, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

