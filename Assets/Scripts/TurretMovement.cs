using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public Vector2 playerPosition;
    public Vector2 turretPosotion;
    public Rigidbody2D rb;
    public GameObject turretBullets;
    public Transform firePoint;
    public float ShootingForce;
    public float cooldownBullet;
    private float nextBulletTime;
    public bool playerEntered;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nextBulletTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = playerPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
      
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(turretBullets, firePoint.position,firePoint.rotation);
        Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * ShootingForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerPosition = collision.gameObject.transform.position;
            playerEntered = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerPosition = collision.gameObject.transform.position;
            if(Time.time > nextBulletTime)
            {
                Shoot();
                nextBulletTime = Time.time + cooldownBullet;
            }
           
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        playerPosition = new Vector2(0,0);
       
    }

}
