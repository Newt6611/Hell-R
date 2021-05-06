using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameFeel : MonoBehaviour
{
    private CinemachineBrain brain;
    private CinemachineVirtualCamera current_cam;

    private bool shaking;
    private bool stoping;

    private void Awake()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }

    private void Start() 
    {
        current_cam = brain.ActiveVirtualCamera as CinemachineVirtualCamera;
    }



    ///////// Stop Screen /////////////////////////
    public void StopScreen(float time) 
    {
        if(stoping)
            return;
        Time.timeScale = 0.0f;
        StartCoroutine(WaitingStop(time));
    }

    private IEnumerator WaitingStop(float time) 
    {
        stoping = true;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1.0f;
        stoping = false;
    }

    ///////////////////////////////////////////////

    ///////// Shake Camera ///////////////////////
    public void ShakeCamera(float intensity, float time)
    {
        if(shaking)
            return;

        CinemachineBasicMultiChannelPerlin perlin = current_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = intensity;
        StartCoroutine(WatingShake(time, perlin));
    }

    private IEnumerator WatingShake(float time, CinemachineBasicMultiChannelPerlin perlin)
    {
        shaking = true;
        yield return new WaitForSeconds(time);
        perlin.m_AmplitudeGain = 0.0f;
        shaking = false;
    }
    /////////////////////////////////////////////







    private void OnEnable() 
    {
        brain.m_CameraActivatedEvent.AddListener(OnVCameraChange);    
    }

    private void OnDisable()
    {
        brain.m_CameraActivatedEvent.RemoveListener(OnVCameraChange);
    }

    private void OnVCameraChange(ICinemachineCamera camera, ICinemachineCamera c) 
    {
        current_cam = camera as CinemachineVirtualCamera;
    }

}
