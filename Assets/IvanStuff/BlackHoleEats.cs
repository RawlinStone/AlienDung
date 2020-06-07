using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleEats : MonoBehaviour
{
    public int damage;
    public GameObject miniSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            spawnMini();
            //spawn mini blackHole
        }


        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
        }
    }

    public void spawnMini()
    {
        Instantiate(miniSpawn, this.transform.position, this.transform.rotation);
    }
}
