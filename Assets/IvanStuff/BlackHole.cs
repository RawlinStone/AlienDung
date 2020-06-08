using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float timeCounter;
    public float speed;
    public float width;
    public float height;
    public Transform ene;
    private Vector3 target;
    


    // Use this for initialization
    void Start()
    {
       
    }
    //used to initialize game before it starts
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target =  new Vector3(this.gameObject.transform.parent.position.x, this.gameObject.transform.parent.position.y,0);
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        transform.position = new Vector3(x, y, this.transform.position.z)+target; 

    }
}
