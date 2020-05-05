using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool isFollow;
    public GameObject currentPlayer;

    void Start()
    {
        //get player1 gameobject
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        currentPlayer = players[0];

        isFollow = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        currentPlayer = collision.gameObject;
        if (collision.tag == "Player")
        {
            isFollow = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isFollow = false;
        }
    }
}