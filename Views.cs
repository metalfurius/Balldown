using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Views : MonoBehaviour
{
    //public Transform player;
    public Vector3 offset;
    
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;
                                                                    /*GameObject player=GameObject.Find("Player");
                                                                    Transform playerpos=player.GetComponent<Transform>();
                                                                    
                                                                    transform.position=playerpos.position+offset;
                                                                    transform.rotation=offsetAngle;*/
    private void Start() {
        currentView=transform;
    }

    private void Update() {
        if(Input.GetKey("a")||Input.GetKey(KeyCode.LeftArrow))
        {
            currentView=views[1];
        }
        if(Input.GetKey("d")||Input.GetKey(KeyCode.RightArrow))
        {
            currentView=views[2];
        }  
        if(!(Input.GetKey("d")||Input.GetKey("a")||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.LeftArrow)))
        {
            currentView=views[0];
        }  
        
    }
    void LateUpdate()
    {
        transform.position=Vector3.Lerp(transform.position,currentView.position,Time.deltaTime*transitionSpeed);
        Vector3 currentAngle=new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x,currentView.transform.rotation.eulerAngles.x,Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y,currentView.transform.rotation.eulerAngles.y,Time.deltaTime*transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z,currentView.transform.rotation.eulerAngles.z,Time.deltaTime*transitionSpeed)
        );
        transform.eulerAngles=currentAngle;
        //transform.position=player.position+offset;
    }
}