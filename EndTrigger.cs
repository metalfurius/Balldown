using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
        FindObjectOfType<GameManager>().CompleteLevel();
        }
        
    }
}
