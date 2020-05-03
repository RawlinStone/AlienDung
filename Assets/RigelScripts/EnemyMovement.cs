using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public EnemyFollow followArea;
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    //walk direction: 0 is up, 1 is right, 2 is down, 3 is left
    private float walkDirection = 2;
    private float angle;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        followArea = followArea.GetComponent<EnemyFollow>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        direction.Normalize();
        movement = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (followArea.isFollow)
        {
            if (angle < 135 && angle > 45)
            {//moving up
                walkDirection = 0;
            }
            else if (angle < 45 && angle > -45)
            {//moving right
                walkDirection = 1;
            }
            else if (angle < -45 && angle > -135)
            {//moving down
                walkDirection = 2;
            }
            else
            {
                walkDirection = 3;
            }

            anim.SetFloat("AlienDirection", walkDirection);
            anim.SetFloat("speed", direction.sqrMagnitude);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
        

    }

    void FixedUpdate()
    {
        if (followArea.isFollow)
        {
            EnemyMove(movement);
        }
    }

    void EnemyMove(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
