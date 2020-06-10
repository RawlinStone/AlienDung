using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject turretExplodes;
    public GameObject[] dropObjects;
    private GameObject[] players;
    public AudioSource audio;
    public GameManager gm;
    void Start()
    {
        health = 50;
        players = GameObject.FindGameObjectsWithTag("Player");
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            gm.totalEnemies -= 1; 
            GameObject effect = Instantiate(turretExplodes, transform.position, Quaternion.identity);
            
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
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    public int RandomDrop()
    {
        int count = Random.Range(1, 100);
        return count;
    }

    public void TurretTakesDamage(int damage)
    {
        audio.Play();
        health -= damage;
    }
}
