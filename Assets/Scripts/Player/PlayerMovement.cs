using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private float moveX;
    private float moveY;
    float moveSpeed;

    [Header("玩家移動速度")]
    public float[] moveSpeeds = { 50, 5, 5, 5 };

    int mode = Mathf.Clamp(Difficulty.static_mode, 0, 3);

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //角色速度依照難易度
        moveSpeed = moveSpeeds[mode];
    }

    // Update is called once per frame
    void Update()
    {
        if( !BtnForEnd.instance.isPause){
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if ( inputX != 0 || inputY !=0 ){
                animator.SetBool("isWalk", true);
                animator.SetFloat("moveX", inputX);
                animator.SetFloat("moveY", inputY);
            }
            else{
                animator.SetBool("isWalk", false);
            }

            transform.Translate(Vector3.right * inputX * moveSpeed * Time.deltaTime + 
            Vector3.up * inputY * moveSpeed * Time.deltaTime, Space.World);

        }
    }
}
