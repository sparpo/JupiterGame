using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kick : MonoBehaviour
{
        public float attackTime;
    public float startTimeAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if( attackTime <= 0 )
        {
            
            if (Input.GetButton("Fire1"))
            {
                this.GetComponent<Collider2D>().enabled = true;
            }
            attackTime = startTimeAttack;
            
        }
        else
        {
            this.GetComponent<Collider2D>().enabled = false;
            attackTime -= Time.deltaTime;

        }
    }
}
