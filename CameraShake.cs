using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class CameraShake : MonoBehaviour
{
    public ShakeData MyShakeData;
    private void Start() {
        CameraShakerHandler.Shake(MyShakeData);
    }
}
