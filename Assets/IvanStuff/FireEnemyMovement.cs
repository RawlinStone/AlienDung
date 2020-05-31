using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyMovement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public GameObject lava;

    public Transform[] placesMove;
    private int randomSpot;
    // Start is called before the first frame update
    
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, placesMove.Length); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, placesMove[randomSpot].position, speed * Time.deltaTime);
        Instantiate(lava,this.transform.position,Quaternion.identity);
        if(Vector3.Distance(transform.position,placesMove[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, placesMove.Length);
                waitTime = startWaitTime; 
            }
            else
            {
                waitTime -= Time.deltaTime; 
            }
        }
    }
}
