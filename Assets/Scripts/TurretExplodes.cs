using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretExplodes : MonoBehaviour
{
    public float range;
    public float despawnTime;
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
}
