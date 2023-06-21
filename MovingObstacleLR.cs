using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleLR : MonoBehaviour
{
    public float speed = 1f;
    private bool going_right = false;
    public float distance=5f;
    Rigidbody rb;
    private float rbpos;

    private void Start() {
        rb=gameObject.GetComponent<Rigidbody>();
        rbpos=gameObject.GetComponent<Rigidbody>().transform.position.x;
    }

    void FixedUpdate() 
    {
        if(going_right) 
        {
            rb.velocity=Vector3.right * speed;
            //transform.Translate(Vector3.right * Time.deltaTime * speed); // Move right
            if(transform.position.x > (rbpos+distance)) // Too far right
            { 
                going_right = false; // Switch direction
            }
        }
        else 
        {
            rb.velocity=-Vector3.right * speed;
            //transform.Translate(-Vector3.right * Time.deltaTime * speed); // Move left
            if(transform.position.x < (rbpos-distance)) // Too far left
            { 
                going_right = true; // Switch direction
            }
        }
}

}
