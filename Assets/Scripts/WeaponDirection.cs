using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (
            Input.GetAxisRaw("Vertical") > 0 && gameObject.name == "Player1WeaponDirection" ||
            Input.GetAxisRaw("Vertical1") > 0 && gameObject.name == "Player2WeaponDirection"
            )
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        else if (
            Input.GetAxisRaw("Vertical") < 0 && gameObject.name == "Player1WeaponDirection" ||
            Input.GetAxisRaw("Vertical1") < 0 && gameObject.name == "Player2WeaponDirection"
            )
        {
            transform.eulerAngles = new Vector3(0f,0f,180f);
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && gameObject.name == "Player1WeaponDirection" ||
            Input.GetAxisRaw("Horizontal1") < 0 && gameObject.name == "Player2WeaponDirection"
            )
        {
            transform.eulerAngles = new Vector3(0f,0f,90f);
        }
        else if (
            Input.GetAxisRaw("Horizontal") > 0 && gameObject.name == "Player1WeaponDirection" ||
            Input.GetAxisRaw("Horizontal1") > 0 && gameObject.name == "Player2WeaponDirection"
            )
        {
            transform.eulerAngles = new Vector3(0f,0f,-90f);
        }
    }
}
