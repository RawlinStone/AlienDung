using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool isFollow;
    public GameObject currentPlayer;
    public GameObject currentEnemy;
    private GameObject[] players;
    public float shortestDistance;

    void Start()
    {
        //get player1 gameobject
        players = GameObject.FindGameObjectsWithTag("Player");
        currentPlayer = players[0];

        isFollow = false;
    }

    void Update()
    {
        //shortestDistance = currentPlayer.transform.position.magnitude - currentEnemy.transform.position.magnitude;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPlayer = collision.gameObject;
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