using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int health;

    private EnemyMovement movement;
    public float slowTimer;
    private float timer;
    private bool hit;
    private float slowSpeed;
    private float speed;

    public ParticleSystem splat;

    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        timer = slowTimer;

        slowSpeed = movement.speed / 2;
        speed = movement.speed;

        splat.Stop();
    }

    void Update()
    {
        if (hit)
        {
            movement.speed = slowSpeed;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = slowTimer;
                hit = false;
            }
        }
        else
        {
            movement.speed = speed;
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;

        //slow the speed down
        hit = true;

        //play take damage animation
        if (movement.walkDirection == 0)
        {
            movement.anim.SetTrigger("DamagedUp");
        }
        else if (movement.walkDirection == 1)
        {
            movement.anim.SetTrigger("DamagedRight");
        }
        if (movement.walkDirection == 2)
        {
            movement.anim.SetTrigger("DamagedDown");
        }
        else
        {
            movement.anim.SetTrigger("DamagedLeft");
        }

        if (health <= 0)
        {
            //enemy dies
            Explode();
            Destroy(this.gameObject);

            //enemy drops ammo
        }
    }

    void Explode()
    {
        splat.transform.parent = null;
        splat.Play();
    }
}
