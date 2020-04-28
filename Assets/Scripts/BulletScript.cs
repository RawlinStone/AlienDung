using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool despawn;
    public float despawnTime;
    public bool explode;
    public GameObject explosion;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (despawn)
        {
            if (timer > despawnTime)
            {
                if (explode)
                {
                    var boom = Instantiate(explosion);
                    boom.transform.position = transform.position;
                }
                Destroy(gameObject);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (explode)
        {
            //instantiate explosion
        }
        else
        {
            //add damage script
        }
    }
}
