using System.Collections;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public ShakeData MyShakeData;

    void OnCollisionEnter(Collision collissionInfo) {
        if(collissionInfo.collider.tag=="Obstacles")
        {
            CameraShakerHandler.Shake(MyShakeData);
            GetComponent<PlayerMovement>().enabled=false;
            FindObjectOfType<GameManager>().EndGame();
            FindObjectOfType<AudioManager>().Play("Death");
            FindObjectOfType<Camera>().GetComponent<CameraFov>().enabled=false;
            if(collissionInfo.gameObject.TryGetComponent(out MovingObstacleLR script))
                collissionInfo.gameObject.GetComponent<MovingObstacleLR>().enabled=false;

            if(collissionInfo.gameObject.TryGetComponent(out MovingObstacleUD script1))
                collissionInfo.gameObject.GetComponent<MovingObstacleUD>().enabled=false;

            
        }
    }
}
