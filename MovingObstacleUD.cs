using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleUD : MonoBehaviour
{
    public float speed = 1f;
    private bool going_right = false;
    public float distance=5f;
    public float floor=0f;
    Rigidbody rb;
    private float rbpos;
    private void Start() {
        rb=gameObject.GetComponent<Rigidbody>();
        rbpos=gameObject.GetComponent<Rigidbody>().transform.position.y;
    }

    void Update() 
    {
        if(going_right) 
        {
            rb.velocity=Vector3.up * speed;
            //transform.Translate(Vector3.right * Time.deltaTime * speed); // Move right
            if(transform.position.y >  rbpos+distance) // Too far right
            { 
                going_right = false; // Switch direction
            }
        }
        else 
        {
            rb.velocity=Vector3.down * speed;
            //transform.Translate(-Vector3.right * Time.deltaTime * speed); // Move left
            if(transform.position.y < rbpos-floor) // Too far left
            { 
                going_right = true; // Switch direction
            }
        }
}

}
