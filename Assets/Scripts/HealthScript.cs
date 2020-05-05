using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change(int amount)
    {
        health += amount;
        if (gameObject.tag == "Player")
        {
            if (health <= 0)
            {
                //do something with death
            }
        }
        //can be changed to elseif if there are different things we need to do with loss of health
        else
        {
            if (health <= 0)
            {
                //do something with death
            }
        }
    }
}
