using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed for player
    public float speed = 5f;

    public Rigidbody2D rb;
   

    //used to store position
    Vector2 movement;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.name == "Player1")
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

        }
        if (transform.parent.name == "Player2")
        {
            movement.x = Input.GetAxisRaw("Horizontal1");
            movement.y = Input.GetAxisRaw("Vertical1");

        }
    }

        void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
    }
}
