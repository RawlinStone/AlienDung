using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGunChargingScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChargingGun(int status)
    {
        //0 is not charging
        //1 is charging
        //2 is done charging
        switch(status)
        {
            case 0:
                anim.SetInteger("Status", 0);
                break;
            case 1:
                anim.SetInteger("Status", 1);
                break;
            case 2:
                anim.SetInteger("Status", 2);
                break;
            default:
                break;
        }

    }
}
