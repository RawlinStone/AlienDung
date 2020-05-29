using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject turretExplodes;
    void Start()
    {
        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject effect = Instantiate(turretExplodes, transform.position, Quaternion.identity);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

    public void TurretTakesDamage(int damage)
    {
        health -= damage;
    }
}
