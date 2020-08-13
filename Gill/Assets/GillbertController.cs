/**
* This script only handles inputs from user. No physics, animation or event handling
*
*
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GillbertController : MonoBehaviour {
    void Update() {

        float h = Input.GetAxis("Horizontal");
        //Crouch with down arrow or S
        if (Input.GetButton("Crouch")) {
            //movin.crouch(h)
        }


        //sprinting with shift
        if(Input.GetButton("Sprint")) {
            //moving.sprint(h)
        } 
       
        //horizontal movement (a d, <- ->)
        if(h != 0 ) {
            //movin.run(h);
        }

        //Jump with up arrow or W
        if (Input.GetButtonDown("Jump")) {
            //movin.jump();
        }

        //Attack button (left click)
        if(Input.GetButtonDown("Fire1")) { //left click
           //movin.kick();
        }
    }
}
