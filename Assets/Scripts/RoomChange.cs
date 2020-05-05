using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public GameObject player1Position;
    public GameObject player2Position;
    public Vector2 changeCameraTop;
    public Vector2 changeCameraBottom;
    public Vector3 playerChange;
    public Vector3 optionalplayerChange;
    public Camera MainCamera;
    public float cameraSize;
    private CameraMovement cam;
    public bool changeOccured;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        MainCamera = Camera.main;
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
            Vector2 temp1 = cam.maxCam;
            Vector2 temp2 = cam.minCam;
            float temp3 = MainCamera.orthographicSize;
            cam.maxCam = changeCameraTop;
            cam.minCam = changeCameraBottom;
            changeCameraTop = temp1;
            changeCameraBottom = temp2;
            MainCamera.orthographicSize = cameraSize;
            cameraSize = temp3;
            if (changeOccured)
            {
                
                collision.gameObject.transform.position -= optionalplayerChange;
                Debug.Log(collision.gameObject.name); 
                if(collision.gameObject.name == "Player1Sprite")
                {
                    player2Position.transform.position = collision.gameObject.transform.position;
                }
                else if (collision.gameObject.name == "Player2Sprite")
                {
                    player1Position.transform.position = collision.gameObject.transform.position;
                }
                changeOccured = false;
            }
            else
            {
                collision.gameObject.transform.position += playerChange;
                Debug.Log(collision.gameObject.name);
                if (collision.gameObject.name == "Player1Sprite")
                {
                    player2Position.transform.position = collision.gameObject.transform.position;
                }
                else if(collision.gameObject.name == "Player2Sprite")
                {
                    player1Position.transform.position = collision.gameObject.transform.position;
                }
                 
              
                changeOccured = true;
            }

           
        }
    }

    

    



    

}
