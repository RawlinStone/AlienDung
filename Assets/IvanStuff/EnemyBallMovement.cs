using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallMovement : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool p1;
    public bool p2;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject go in players)
        {
            if (p1 && go.gameObject.name == "Player1Sprite")
            {
                player = go.transform;
            }
            else if (p2 && go.gameObject.name == "Player2Sprite")
            {
                player = go.transform;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        
    }

    private void FixedUpdate()
    {
        move(movement);
    }

    private void move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.name == collision.gameObject.name) {
            collision.gameObject.GetComponent<PlayerAmmoScript>().changeAmmo(-1);  
        }
    }




}
