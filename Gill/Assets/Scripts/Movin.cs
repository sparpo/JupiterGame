using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//movin right along

public class Movin : MonoBehaviour { 
    //just to note, its good to initialize varaibles here but not give them a value. 
    //Set them inside the editor or inside Start()
    public float maxRunSpeed;
    public float maxSprintSpeed;
    public float maxCrawlSpeed;
    public float acceleration;
    public float decceleration;

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
    }


    void Update() {

        

        float speed = maxRunSpeed;
        //Crouch with down arrow or S
        if (Input.GetButton("Crouch")) {
            animator.SetBool("crawlAnimate", true);
            speed = maxCrawlSpeed;
        }
        else {
            animator.SetBool("crawlAnimate", false);
        }

        //sprinting with shift
        if(Input.GetButton("Sprint")) {
            speed = maxRunSpeed;
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
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x * Time.deltaTime* (1/decceleration), rigidbody.velocity.y);
            //Vector2 v = new Vector2(rigidbody.velocity.x * -decceleration, rigidbody.velocity.y);
            rigidbody.AddForce(new Vector2(rigidbody.velocity.x * -decceleration, rigidbody.velocity.y));
        }


        //Moves with left & right arrow, or A & D
        Vector3 movement = new Vector2(h, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;   
        if(rigidbody.velocity.magnitude < speed) {//limits max speed
            rigidbody.AddForce(movement * acceleration);
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
            ///AudioSource.PlayOneShot(Kick);
        } else {
            animator.SetBool("kickAnimate", false);
        }
    }


  private void FixedUpdate() {

    }
}
