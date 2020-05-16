using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject[] players;
    private Transform targetPlayer;
    public EnemyFollow followArea;
    private Rigidbody2D rb;

    public float speed;
    private Vector2 movement;

    //walk direction: 0 is up, 1 is right, 2 is down, 3 is left
    [SerializeField]
    public float walkDirection = 2;
    private float angle;
    public Animator anim;

    public GameObject changeAttackPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        followArea = followArea.GetComponent<EnemyFollow>();

    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer = followArea.currentPlayer.transform;

        Vector3 direction = targetPlayer.position - transform.position;

        direction.Normalize();
        movement = direction;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (followArea.isFollow)
        {
            if (angle < 135 && angle > 45)
            {//moving up
                walkDirection = 0;
                changeAttackPosition.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            }
            else if (angle < 45 && angle > -45)
            {//moving right
                walkDirection = 1;
                changeAttackPosition.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y - .25f);
            }
            else if (angle < -45 && angle > -135)
            {//moving down
                walkDirection = 2;
                changeAttackPosition.transform.position = new Vector2(transform.position.x, transform.position.y-1);
            }
            else
            {
                walkDirection = 3;
                changeAttackPosition.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.25f);
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
