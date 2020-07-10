using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//movin right along

public class Movin : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public bool runAnimate;
    private Rigidbody2D rigidbody;
    public Animator animator;
    public bool isGrounded = false;

    void Start() {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("runAnimate", false);
        jumpHeight = 10f;
    }


    void Update() {
        if(Input.GetButton("Sprint")) {
            moveSpeed = 7f;
        } else {
            moveSpeed = 5f;
        }

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

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rigidbody.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
            }
        }
    }


  private void FixedUpdate() {

    }
}
