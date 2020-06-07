using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class miniBlackMovement : MonoBehaviour
{
    public GameObject[] playersLocation;
    private float currentAngle;
    public float speed;
    private float distancePlayer;
    public Vector3 closestPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = 0;
        playersLocation = GameObject.FindGameObjectsWithTag("Player");
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Mathf.Infinity;
        foreach (GameObject t in playersLocation)
        {
            
            float dist = (t.transform.position - this.transform.position).sqrMagnitude;
            
            if(dist < distancePlayer)
            {
                
                closestPlayer = new Vector3(t.transform.position.x,t.transform.position.y,t.transform.position.z);
                distancePlayer = dist;
            }
            
        }
       
        changeAngle();
        move();
    }

    private void move()
    {
        float x = speed * Mathf.Cos(currentAngle);
        float y = speed * Mathf.Sin(currentAngle);
        this.transform.position += new Vector3(x, y, 0);
    }

    private void changeAngle()
    {
        Vector3 temp = new Vector3(closestPlayer.x - this.transform.position.x, closestPlayer.y - this.transform.position.y, 0);
        
        float newAngle = Mathf.Atan2(temp.y, temp.x);
        currentAngle = newAngle;
    }
}
