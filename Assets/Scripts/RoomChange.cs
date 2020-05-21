using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Transform player1pos;
    public Transform player2pos;
    public Camera cam;
    public float camSize;
    public Vector3 roomTransform;
    public Vector3 playerMove;



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
            changeCameraSize();
            changeCameraPosition();
            if(collision.gameObject.name == "Player1Sprite")
            {
                collision.gameObject.transform.position += playerMove;
                player2pos.transform.position = collision.gameObject.transform.position;
                playerMove = -playerMove;
            }
            else if (collision.gameObject.name == "Player2Sprite")
            {
                collision.gameObject.transform.position += playerMove;
                player1pos.transform.position = collision.gameObject.transform.position;
                playerMove = -playerMove;
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
        cam.transform.position = roomTransform;
        roomTransform = temp;

    }









}
