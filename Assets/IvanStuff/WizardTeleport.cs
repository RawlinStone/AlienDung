using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTeleport : MonoBehaviour
{
    public Transform[] teleport;
    private int randomSpot;
    public GameObject teleportParticles;
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
            GameObject effect1 = Instantiate(teleportParticles, this.transform.position, this.transform.rotation);
           
            this.transform.parent.position = new Vector3(teleport[randomSpot].transform.position.x, teleport[randomSpot].transform.position.y, teleport[randomSpot].transform.position.z);
            
            GameObject effect2 = Instantiate(teleportParticles, this.transform.position, this.transform.rotation);
            int current = randomSpot;
            while(current == randomSpot)
            {
                randomSpot = Random.Range(0, teleport.Length);
            }
            
            Destroy(effect1, 2f);
            Destroy(effect2, 2f);

        }
    }
}
