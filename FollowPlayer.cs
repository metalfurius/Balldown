using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public Transform player;
    public Vector3 offset;
    public Quaternion offsetAngle;

    private void Start() {
        
    }
    void LateUpdate()
    {
        //transform.position=player.position+offset;
        //transform.rotation=offsetAngle;

        GameObject player=GameObject.FindGameObjectWithTag("Player");
        Transform playerpos=player.GetComponent<Transform>();
        
        transform.position=playerpos.position+offset;
        transform.rotation=offsetAngle;

    }
}
