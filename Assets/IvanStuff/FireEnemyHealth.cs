using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyHealth : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyFireBallDamage(int damage)
    {
        health -= damage; 
    }
}
