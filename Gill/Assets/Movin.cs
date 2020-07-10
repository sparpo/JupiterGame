using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//movin right along
public class Movin : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public bool runAnimate;
    private Rigidbody2D rigidbody;
    public Animator animator;

    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("runAnimate", false);
        jumpHeight = 10f;
    }


    void Update()
    {

    }


  private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        

        //animation triggers    -   for whatever reason, 
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("runAnimate", true);
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            animator.SetBool("runAnimate", true);
        }
        else 
                {
            animator.SetBool("runAnimate", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
        }
    }
}
