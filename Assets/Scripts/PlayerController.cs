using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player2D;
    float jumpForce = 250f;
    float dir = 2.25f;

    int jumpCount = 0;
    int maxJumpCount = 2;

    PlayerStatus status;
    Vector3 respawnPoint;
    void Start()
    {
        this.player2D = GetComponent<Rigidbody2D>();
        this.status = GetComponent<PlayerStatus>();
        respawnPoint = new Vector3(0f, 4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount)
        {
            this.player2D.velocity = new Vector2(player2D.velocity.x, 0);
            this.player2D.AddForce(transform.up * this.jumpForce);
            jumpCount++;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dir * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-dir * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "cloud")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("撞到雲");
                dir = 2.25f;
                jumpCount = 0;
                transform.parent = other.transform;
            }
        } else if (other.gameObject.tag == "thundercloud")
        {
            Debug.Log("撞到雷雲");
            transform.parent = other.transform;
            jumpCount = 1;
            dir = 1.5f;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "boundary")
        {
            Debug.Log("掉出邊界，扣血");
            status.TakeDamage(1);
            transform.position = respawnPoint;
            player2D.velocity = Vector2.zero;
        }
    }
}
