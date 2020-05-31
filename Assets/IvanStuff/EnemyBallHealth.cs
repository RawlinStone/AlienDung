using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallHealth : MonoBehaviour
{
    public int health;
    public GameObject playerDies;
    // Start is called before the first frame update
    void Start()
    {
        health = 25; 
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(playerDies, this.transform.position, this.transform.rotation);
            Destroy(gameObject); 
            //play some particle
        }
    }

    public void BallTakeDamage(int damage)
    {
        health -= damage; 
    }
}
