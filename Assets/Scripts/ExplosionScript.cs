using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float range;
    public float despawnTime;
    public int damage;
    private float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(range, range, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < despawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    

    void OnTriggerEnter2D(Collider2D collide)
    {
        //deal damage
        Debug.Log(collide.tag);
        if (collide.tag == "Enemy")
        {
            collide.GetComponent<EnemyHealthSystem>().EnemyTakeDamage(damage);
        }
        else if(collide.CompareTag("Turret"))
        {
            Debug.Log("Turret");
            collide.GetComponent<TurretHealth>().TurretTakesDamage(damage);
        }
        else if (collide.CompareTag("FireEnemy"))
        {
            collide.GetComponent<FireEnemyHealth>().EnemyFireBallDamage(damage);
        }
        else if (collide.CompareTag("Wizard"))
        {
            Debug.Log("wizard");
            collide.GetComponent<WizardHealth>().WizardEnemyTakeDamage(damage);
        }
        else if (collide.CompareTag("BlackH"))
        {
            Debug.Log("Explosion Script");
            Destroy(gameObject);
        }
        
    }
}
