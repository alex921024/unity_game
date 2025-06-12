using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Floor : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float B = 0.1f;
    public float m = 0;
    

    void OnEnable()
    {
        
        m = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        m = moveSpeed + Time.time * B;
        transform.Translate(-m * Time.deltaTime, 0, 0);
        if (transform.position.x < -9f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<FloorManager>().SpawnFoolr();
        }
    }
}
