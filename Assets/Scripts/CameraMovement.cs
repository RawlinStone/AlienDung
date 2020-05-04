using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxCam;
    public Vector2 minCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 positiont = new Vector3(target.position.x, target.position.y, transform.position.z);
            positiont.x = Mathf.Clamp(positiont.x, minCam.x, maxCam.x);
            positiont.y = Mathf.Clamp(positiont.y, minCam.y, maxCam.y);
            transform.position = Vector3.Lerp(transform.position, positiont, smoothing);
        }
    }
}
