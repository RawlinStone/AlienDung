using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoScript : MonoBehaviour
{
    public int ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAmmo(int change)
    {
        int temp = ammo;
        temp += change;
        if(temp <= 0)
        {
            ammo = 0; 
        }
        else
        {
            ammo += change;
        }
        
    }

    public bool canShoot(int amount)
    {
        return ammo>=amount;
    }
}
