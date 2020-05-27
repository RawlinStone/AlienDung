using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public GameObject player1pos;
    public GameObject player2pos;
    public Camera cam;
    public float camSize;
    public Vector3 roomTransform;
    public Vector3 playerMove;
    public float cameraZDefault;
    public AudioSource audio;
    





    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    

    void FixedUpdate()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
           Debug.Log(collision.gameObject.name);
           audio.Play();
           changeCameraSize();
           changeCameraPosition();
            

            if (collision.gameObject.name == "Player1Sprite")
               {
                  player1pos.transform.position += playerMove;
                  player2pos.transform.position = player1pos.transform.position;
                  playerMove = -playerMove;
                  Invoke("changeDefault", 1.0f);
                    
               }
             else if (collision.gameObject.name == "Player2Sprite")
                {
                  player2pos.transform.position += playerMove;
                  player1pos.transform.position = player2pos.transform.position;
                  playerMove = -playerMove;
                  Invoke("changeDefault", 1.0f);
                    
                }
        }






        
    }

    private void changeCameraSize()
    {
        float tempSize = cam.orthographicSize;
        cam.orthographicSize = camSize;
        camSize = tempSize;
    }

    private void changeCameraPosition()
    {
        Vector3 temp = cam.transform.position;
        cam.transform.position = new Vector3(roomTransform.x,roomTransform.y, 0);
        roomTransform = temp;

    }

    private void changeDefault()
    {
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cameraZDefault);
       
    }

   









}
