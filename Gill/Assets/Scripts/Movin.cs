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
    public Rigidbody2D rigidbody;
    public Animator animator;
    public bool isGrounded = false;

    void Start() {
        animator.SetBool("runAnimate", false);
        animator.SetBool("jumpAnimate", false);
        animator.SetBool("crawlAnimate", false);
        animator.SetBool("kickAnimate", false);
        animator.SetBool("sprintAnimate", false);
        jumpHeight = 10f;
        moveSpeed = 5f;
    }


    void Update() {

        

        moveSpeed = 5;
        //Crouch with down arrow or S
        if (Input.GetButton("Crouch")) {
            animator.SetBool("crawlAnimate", true);
            moveSpeed = 2;
        }
        else {
            animator.SetBool("crawlAnimate", false);
        }

        //sprinting with shift
        if(Input.GetButton("Sprint")) {
            moveSpeed = 7;
            animator.SetBool("sprintAnimate", true);
        } 
        else {
            animator.SetBool("sprintAnimate", false);
        }
        //horizontal movement
        float h = Input.GetAxis("Horizontal");
        if (h < -0.1)
        {
            animator.SetBool("runAnimate", true);
                if (transform.rotation != Quaternion.Euler(0, 180, 0))
                transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (h > 0.1)
        {
            animator.SetBool("runAnimate", true);
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else 
                {
            animator.SetBool("runAnimate", false);

            //slow down when not moving
            rigidbody.velocity = new Vector2(rigidbody.velocity.x * Time.deltaTime* 0.8f, rigidbody.velocity.y);
        }


        //Moves with left & right arrow, or A & D
        Vector3 movement = new Vector3(h, 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;   
        if(rigidbody.velocity.magnitude < moveSpeed) {//limits max speed
            rigidbody.AddForce(movement * moveSpeed);
        }
        


        //Jump with up arrow or W
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



        //Attack button
        if(Input.GetButtonDown("Fire1")) { //left click
            animator.SetBool("kickAnimate", true);
        } else {
            animator.SetBool("kickAnimate", false);
        }
    }


  private void FixedUpdate() {

    }
}
