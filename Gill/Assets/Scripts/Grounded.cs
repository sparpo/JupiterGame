using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Animator groundAnimator;
    public GameObject Gillbert;
    // Start is called before the first frame update
    void Start()
    {
        //Gillbert = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundAnimator.SetBool("grounded", true);
            Gillbert.GetComponent<Movin>().isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            groundAnimator.SetBool("grounded", false);
            Gillbert.GetComponent<Movin>().isGrounded = false;
        }
    }
}
