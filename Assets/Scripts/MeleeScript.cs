using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public float cooldown;
    public int damage;
    private float timer = 0.0f;
    public float attackRange;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("attack", false);
        if ((Input.GetButton("Fire1") && transform.parent.name == "Player1Weapon") || 
        (Input.GetButton("Fire2") && transform.parent.name == "Player2Weapon"))
        {
            if (timer <= 0.0)
            {
                timer = cooldown;
                anim.SetBool("attack", true);
                Attack();
            }
        }
        if (timer > 0.0)
        {
            timer -= Time.deltaTime;
        }
        
    }

    void Attack()
    {
        Collider2D[] attacked = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var collide in attacked)
        {
            if (collide.tag == "Enemy")
            {
                // Debug.Log("deal damage");
                collide.GetComponent<EnemyHealthSystem>().EnemyTakeDamage(damage);
            }
            else if (collide.CompareTag("Turret"))
            {
                collide.GetComponent<TurretHealth>().TurretTakesDamage(damage);

            }
            else if (collide.CompareTag("BallEnemy"))
            {
                collide.GetComponent<EnemyBallHealth>().BallTakeDamage(damage); 
            }
            else if (collide.CompareTag("FireEnemy"))
            {
                collide.GetComponent<FireEnemyHealth>().EnemyFireBallDamage(damage); 
            }
            //need to see how enemy takes damage before done
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}
