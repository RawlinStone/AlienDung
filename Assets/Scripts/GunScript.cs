using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float cooldown;
    public int ammoUse;
    public AudioClip[] soundeffects;
    private AudioSource audiosource;

    private PlayerAmmoScript ammo;
    public bool infiniteAmmo;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        ammo = transform.parent.parent.parent.GetComponent<PlayerAmmoScript>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1") && transform.parent.name == "Player1Weapon") || 
        (Input.GetButton("Fire2") && transform.parent.name == "Player2Weapon"))
        {
            if (timer <= 0 && ammo.canShoot(ammoUse))
            {
                //Debug.Log(timer);
                if (!infiniteAmmo)
                {
                    ammo.changeAmmo(-ammoUse);
                }
                audiosource.PlayOneShot(soundeffects[Random.Range(0, soundeffects.Length)]) ;
                var projectile = Instantiate(bullet);
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation; 
                projectile.GetComponent<Rigidbody2D>().velocity = (projectile.transform.position - transform.parent.parent.position) * bulletSpeed;
                timer = cooldown;
            }
        }
        
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
