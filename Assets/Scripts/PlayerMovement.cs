using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed for player
    public float speed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public float px;
    public float py;
    
    
   

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
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        if (px > movement.x)
        {
            
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }

        if (px < movement.x)
        {
          
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }

        if (py < movement.y)
        {
          
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }

        if (py > movement.y)
        {
            
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
        }
        px = movement.x;
        py = movement.y;
    }

        void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        
    }

    
}