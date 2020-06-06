using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTeleport : MonoBehaviour
{
    public Transform[] teleport;
    private int randomSpot;
    // Start is called before the first frame update
    
    void Start()
    {
        randomSpot = Random.Range(0, teleport.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play particle
            transform.position = new Vector3(teleport[randomSpot].transform.position.x, teleport[randomSpot].transform.position.y, teleport[randomSpot].transform.position.z);
            randomSpot = Random.Range(0, teleport.Length); 
        }
    }
}
