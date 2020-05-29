using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool isFollow;
    public GameObject currentPlayer;
    public GameObject currentEnemy;
    private GameObject[] players;
    private float shortestDistance;

    void Start()
    {
        //get player1 gameobject
        players = GameObject.FindGameObjectsWithTag("Player");
        currentPlayer = players[0];
        shortestDistance = currentPlayer.transform.position.magnitude - currentEnemy.transform.position.magnitude;

        isFollow = false;
    }

    void Update()
    {
        shortestDistance = currentPlayer.transform.position.magnitude - currentEnemy.transform.position.magnitude;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < players.Length; i++)
        {
            float distance = players[i].transform.position.magnitude - currentEnemy.transform.position.magnitude;
            Debug.Log(players[i].name + " " + distance);
            Debug.Log(shortestDistance);
            if (distance <= shortestDistance)
            {
                currentPlayer = players[i].gameObject;
                isFollow = true;
            }
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