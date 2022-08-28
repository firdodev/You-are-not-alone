using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float runSpeed = 5f;
    private float x,y;
    private bool isWalking;
    public bool canPlayerMove;
    Vector2 movement;

    //References
    public Rigidbody2D rb;
    public Animator animator;


    void Start()
    {
        canPlayerMove = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCutscene.isCutsceneOn)
        {
            canPlayerMove = true;
        }
        if(!canPlayerMove)
            return;

        //Movement//
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(x != 0 || y != 0)
        {
            if(isWalking)
            {
                isWalking = false;
                animator.SetBool("isWalking", isWalking);
            }

            Move();
        }
        else
        {
            if(!isWalking)
            {
                isWalking = true;
                animator.SetBool("isWalking", isWalking);
            }
        }

       bool isMoving = Mathf.Abs(x)>Mathf.Epsilon;
       if(isMoving)
       {
           transform.localScale = new Vector2(Mathf.Sign(x),1f);
       }
    }

    private void Move()
    {
        animator.SetFloat("Horizontal",x);
        animator.SetFloat("Vertical",y);

        transform.Translate(x * Time.deltaTime * runSpeed, y * Time.deltaTime * runSpeed,0);
    }

    // private void FlipSprite()
    // {
    //     bool isMoving = Mathf.Abs(movement.x)>Mathf.Epsilon;
    //     if(isMoving)
    //     {
    //         transform.localScale = new Vector2(Mathf.Sign(movement.x),1f);
    //     }
    // }
}
