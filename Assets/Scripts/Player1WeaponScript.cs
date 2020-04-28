using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1WeaponScript : MonoBehaviour
{
    private int currentWeapon = 0;
    private GameObject melee;
    private GameObject gun;
    private GameObject heavyGun;
    // Start is called before the first frame update
    void Start()
    {
        melee = transform.GetChild(0).gameObject;
        gun = transform.GetChild(1).gameObject;
        heavyGun = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Player1WeaponSwap"))
        {
            currentWeapon = (currentWeapon + 1) % 3;

            melee.SetActive(false);
            gun.SetActive(false);
            heavyGun.SetActive(false);

            switch (currentWeapon)
            {
                case 0:
                    melee.SetActive(true);
                    break;
                case 1:
                    gun.SetActive(true);
                    break;
                case 2:
                    heavyGun.SetActive(true);
                    break;
            }

            //Debug.Log(currentWeapon);
        }
    }
}
