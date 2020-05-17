using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int health;
    public int damage;

    void EnemyTakeDamage(int damage)
    {
        health -= damage;

        //TODO: slow the speed down
        //TODO: play take damage animation

        if (health <= 0)
        {
            //enemy dies
        }
    }

    void EnemyDealDamage()
    {

    }
}
