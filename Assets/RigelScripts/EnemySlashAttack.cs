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
        if (attackTime <= 0)
        {
            //enemy attack
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, attackPlayers);
            for (int i = 0; i < playersToDamage.Length; i++)
            {
                //do damage
                Debug.Log("player attacked");
            }
            attackTime = attackCoolDown;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
