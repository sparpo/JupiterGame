﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Crouch"))
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
