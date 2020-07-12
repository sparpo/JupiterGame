using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//movin right along

public class Movin : MonoBehaviour { 
    //just to note, its good to initialize varaibles here but not give them a value. 
    //Set them inside the editor or inside Start()
    public float moveSpeed;
    public float jumpHeight;
    public bool runAnimate;
    private Rigidbody2D rigidbody;
    public Animator animator;
    public bool isGrounded = false;

    void Start() {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("runAnimate", false);
        animator.SetBool("jumpAnimate", false);
        animator.SetBool("crawlAnimate", false);
        animator.SetBool("kickAnimate", false);
        jumpHeight = 10f;
        moveSpeed = 5f;
    }


    void Update() {

        //Sprint with shift
        if(Input.GetButton("Sprint")) { 
            moveSpeed = 7f;
        } else {
            moveSpeed = 5f;
        }


        //Moves with left & right arrow, or A & D
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;       

        
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("runAnimate", true);
                if (transform.rotation != Quaternion.Euler(0, 180, 0))
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            animator.SetBool("runAnimate", true);
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else 
                {
            animator.SetBool("runAnimate", false);
        }

        //Jump with up arrow
        if (Input.GetButtonDown("Jump"))
        {
            //Check if player is grounded
            if (isGrounded)
            {
                animator.SetBool("jumpAnimate", true);
                rigidbody.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
            } 
        }
        else {
                animator.SetBool("jumpAnimate", false);
        }
    }


  private void FixedUpdate() {

    }
}
