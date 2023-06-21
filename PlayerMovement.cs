using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce=2000f;
    public float sideForce=500f;
    public Vector3 jump;
    public float jumpForce = 20.0f;
    public float speed;
    public Animator animator;

    public bool isGrounded;
    private float cooldown = 0.75f;
    private float lastSwing;
    Scene m_Scene;
    string sceneName;
    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        animator= FindObjectOfType<Score>().GetComponent<Animator>();
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void Update(){
        if (!(sceneName=="Shop"|sceneName=="LevelSelect"))
            {
                animator.SetFloat("Speed",speed);
            }
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded){
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;  
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
            isGrounded = false;
            
        }}




    void FixedUpdate() {
        speed=rb.velocity.magnitude;
        rb.AddForce(0,0,(forwardForce*0.45f)*Time.deltaTime);//bola mueve sola
        if(Input.GetKey("w")||Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0,0,(forwardForce*0.65f)*Time.deltaTime);
        }
        if(Input.GetKey("d")||Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sideForce*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if(Input.GetKey("a")||Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sideForce*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if(rb.position.y<-3)
        {
            FindObjectOfType<GameManager>().EndGame();
        }


    }
    
}
