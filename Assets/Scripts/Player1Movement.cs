using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    //speed for player
    public float speed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    //used to store position
    Vector2 movement;
    Vector2 mousePosition;
    Vector2 aim;
    float playerAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        aim = mousePosition - rb.position;
        playerAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = playerAngle;
    }
}
