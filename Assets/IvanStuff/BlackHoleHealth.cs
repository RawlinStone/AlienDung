using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleHealth : MonoBehaviour
{
    public int health;
    public float despawnTime;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = despawnTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject); 
        }
        
        if(counter <= 0)
        {
            counter = despawnTime;
            this.transform.localScale -= new Vector3(1, 1, 0);
            health -= 1;
        }
        else
        {
            counter -= Time.deltaTime;
        }
    }
}
