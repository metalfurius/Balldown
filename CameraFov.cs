using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFov : MonoBehaviour
{
 public float startFOV = 60f;
 public float maxFOV = 90f;
     
 public Camera myCamera;
 public float t = 0.5f;
 void Update()
 {
     if (Input.GetKey("w")||Input.GetKey(KeyCode.UpArrow)) {
         myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, maxFOV, t *Time.deltaTime);
     } else 
         myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, startFOV, t*Time.deltaTime*0.5f);
     
     }
     
 }
