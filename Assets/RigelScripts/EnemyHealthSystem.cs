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

    public GameObject[] dropObjects;
    private GameObject[] players;

    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        timer = slowTimer;

        slowSpeed = movement.speed / 2;
        speed = movement.speed;

        splat.Stop();

        players = GameObject.FindGameObjectsWithTag("Player");
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

            //drop ammo or health
            bool flag = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<PlayerHealth>().health < 100)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {//if player health is less than 100 than have chance to drop health
                int chance = RandomDrop();
                if (chance <= 45)
                {//45% chance to drop ammo
                    //drop ammo
                    Instantiate(dropObjects[0], transform.position, Quaternion.identity);
                }
                else if (chance > 45 && chance <= 90)
                {//45% to drop health if any of the players health is below 100
                    //drop health
                    Instantiate(dropObjects[1], transform.position, Quaternion.identity);
                }
                else
                {//10% to drop nothing
                    //drop nothing
                }
            }
            else
            {
                int chance = RandomDrop();
                if (chance <= 90)
                {//90% to drop ammo
                    //drop ammo
                    Instantiate(dropObjects[0], transform.position, Quaternion.identity);
                }
                else
                {
                    //drop nothing
                }
            }

            Destroy(this.gameObject);
        }
    }

    public int RandomDrop()
    {
        int count = Random.Range(1, 100);
        return count;
    }

    void Explode()
    {
        splat.transform.parent = null;
        splat.Play();
    }
}
