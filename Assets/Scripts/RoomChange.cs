using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Camera cam;
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public GameObject p1;
    public GameObject p2;
    public GameObject p11;
    public GameObject p22;
    public GameObject p1position;
    public GameObject p2position;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.CompareTag("Player"))
        {
            if (Up)
            {
                Vector3 update = new Vector3();
                update.y += 12;
                cam.transform.position = new Vector3(cam.transform.position.x, update.y + cam.transform.position.y, cam.transform.position.z);
                p1position.transform.position = p1.transform.position;
                p2position.transform.position = p2.transform.position;
                Up = false;
                Down = true;
                switchSpawn(); 
            }
            else if (Down) 
            {
                Vector3 update = new Vector3();
                update.y -= 12;
                cam.transform.position = new Vector3(cam.transform.position.x, update.y + cam.transform.position.y, cam.transform.position.z);
                p1position.transform.position = p1.transform.position;
                p2position.transform.position = p2.transform.position;
                Down = false;
                Up = true; 
                switchSpawn();

            }

            else if (Left)
            {
                Vector3 update = new Vector3();
                update.x -= 20;
                cam.transform.position = new Vector3(update.x + cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                p1position.transform.position = p1.transform.position;
                p2position.transform.position = p2.transform.position;
                Left = false;
                Right = true;
                switchSpawn();
            }
            else if (Right)
            {
                Vector3 update = new Vector3();
                update.x += 20;
                cam.transform.position = new Vector3(update.x + cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                p1position.transform.position = p1.transform.position;
                p2position.transform.position = p2.transform.position;
                Left = true;
                Right = false;
                switchSpawn();
            }

        }
    }

    private void switchSpawn()
    {
        GameObject temp1 = p1;
        GameObject temp2 = p2;
        p1 = p11;
        p2 = p22;
        p11 = temp1;
        p22 = temp2;
    }

    

}
