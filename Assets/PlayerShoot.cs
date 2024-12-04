using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Bullet;

    public float bulletDamage;

    float ShootDelay = 0.1f;

    private int damage = 1;

    public TMP_Text damageText;
    void Start()
    {
        InvokeRepeating(nameof(ShootBullet), 0f, ShootDelay);
        damageText.text = "Damage : " + damage.ToString();
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Bullet.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20, ForceMode.Impulse);

        if(damage <= 0)
        {
            damage = 1;
        }

        bullet.GetComponent<Bullet>().damage = bulletDamage;


        Destroy(bullet, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

