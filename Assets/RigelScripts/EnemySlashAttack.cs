using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemySlashAttack : MonoBehaviour
{
    private float attackTime;
    public float attackCoolDown;
    public int damage;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask attackPlayers;

    private EnemyMovement movement;
    public Animator slashAnim;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<EnemyMovement>();
        attackTime = attackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        //cool down
        if (attackTime < 0)
        {
            
            //check if any of the players are in the attack zone
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, attackPlayers);
            if (playersToDamage.Length > 0)
            {
                //deal damage to each player
                for (int i = 0; i < playersToDamage.Length; i++)
                {
                    //do damage
                    Debug.Log("player attacked");
                }

                //play animation
                //slashAnim.SetFloat("Alien1AttackDirection", movement.walkDirection);
                if (movement.walkDirection == 0)
                {
                    slashAnim.SetTrigger("Up");
                }
                else if (movement.walkDirection == 1)
                {
                    slashAnim.SetTrigger("Right");
                }
                else if (movement.walkDirection == 2)
                {
                    slashAnim.SetTrigger("Down");
                }
                else if (movement.walkDirection == 3)
                {
                    slashAnim.SetTrigger("Left");
                }

                //reset the cooldown
                attackTime = attackCoolDown;
            }
            else
            {
                slashAnim.SetTrigger("Idle");
                //set the attack timer back to 0
                attackTime = 0;
            }
        }
        else
        {
            slashAnim.SetBool("Idle", true);

            //decrease timer
            attackTime -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
