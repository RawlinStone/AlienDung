using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardHealth : MonoBehaviour
{
    public int health;
    public GameObject wizardDeath;
    public GameObject[] dropObjects;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //play particle despawn
            GameObject t = Instantiate(wizardDeath,this.transform.position, this.transform.rotation);
            Destroy(t, 2f);
           
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
            Destroy(gameObject);
        }
    }

    public int RandomDrop()
    {
        int count = Random.Range(1, 100);
        return count;
    }

    public void WizardEnemyTakeDamage(int damage)
    {
        health -= damage;
    }

}
