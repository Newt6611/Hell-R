using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    public SceneOneBossCamera camera_effect;
    public SceneOneBoss boss;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        boss.UpdateState("roar");
        camera_effect.TriggerCameraEffect();
        Destroy(this.gameObject);
    }
}
