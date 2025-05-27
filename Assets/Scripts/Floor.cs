using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    float moveSpeed = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -6.5f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<FloorManager>().SpawnFoolr();
        }
    }
}
