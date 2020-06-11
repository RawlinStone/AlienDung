using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeLimit;
    private float spawnTime;
    public GameObject[] spawnEnemies;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime >= timeLimit)
        {
            int ran = Random.Range(0, spawnEnemies.Length);
            Instantiate(spawnEnemies[ran], this.transform.position, this.transform.rotation);
            spawnTime = 0;
        }
        spawnTime += Time.deltaTime;
        Debug.Log(spawnTime); 
    }
}
