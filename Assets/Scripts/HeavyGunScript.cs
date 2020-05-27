using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGunScript : MonoBehaviour
{
    public float chargeTime;
    public float bulletSpeed;
    public GameObject bullet;
    public int ammo;
    public bool infiniteAmmo;

    private HeavyGunChargingScript chargeAnim;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        chargeAnim = transform.GetChild(0).GetComponent<HeavyGunChargingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1") && transform.parent.name == "Player1Weapon") || 
        (Input.GetButton("Fire2") && transform.parent.name == "Player2Weapon"))
        {
            if (timer < chargeTime)
            {
                chargeAnim.ChargingGun(1);
                timer += Time.deltaTime;
                Debug.Log("Charging");
            }
            else
            {
                chargeAnim.ChargingGun(2);
                Debug.Log("done");
            }
        }
        else
        {
            chargeAnim.ChargingGun(0);
            if (timer < chargeTime && timer > 0.0f)
            {
                chargeAnim.ChargingGun(1);
                timer -= Time.deltaTime;
            }
            if (timer >= chargeTime && ammo > 0)
            {
                if (!infiniteAmmo)
                {
                    ammo--;
                }
                timer = 0.0f;
                var projectile = Instantiate(bullet);
                projectile.transform.position = transform.position;
                projectile.GetComponent<Rigidbody2D>().velocity = (projectile.transform.position - transform.parent.parent.position) * bulletSpeed;
            }
        }
    }
}
