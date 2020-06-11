using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActive : MonoBehaviour
{
    // Start is called before the first frame update
    public bool activeSpawn;
    public GameObject Spawner1;
    public GameObject Spawner2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!activeSpawn)
            {
                Spawner1.SetActive(true);
                Spawner2.SetActive(true);
                activeSpawn = true;
            }
            else if (activeSpawn)
            {
                Spawner1.SetActive(false);
                Spawner2.SetActive(false);
                activeSpawn = false;
            }
        }
    }
}
