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
            GetComponent<Animator>().SetBool("jump", true);
            this.player2D.velocity = new Vector2(player2D.velocity.x, 0);
            this.player2D.AddForce(transform.up * this.jumpForce);
            jumpCount++;
            GetComponent<Animator>().SetBool("run", true);
        }
  


        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dir * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("run", true);
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-dir * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
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
                GetComponent<Animator>().SetBool("jump", false); 
            }
        } else if (other.gameObject.tag == "thundercloud")
        {
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                Debug.Log("撞到雷雲");
                transform.parent = other.transform;
                jumpCount = 1;
                dir = 1.5f;
                GetComponent<Animator>().SetBool("jump", false);
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "cloud" || other.gameObject.tag == "thundercloud") 
        {
            transform.parent = null;
            
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
