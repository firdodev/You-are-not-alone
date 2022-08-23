using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float runSpeed = 5f;

    //References
    public Rigidbody2D rb;
    Vector2 move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ///Movement///
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        //////////////
        
        FlipSprite();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * runSpeed * Time.deltaTime);
    }

    private void FlipSprite()
    {
        bool isMoving = Mathf.Abs(move.x) > Mathf.Epsilon;
        if(isMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(move.x),1f);
        }
    }
}
