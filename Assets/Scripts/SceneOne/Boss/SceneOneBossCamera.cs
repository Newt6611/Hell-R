using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class SceneOneBossCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtual_cam;

    [SerializeField] private InputReader input_reader;
    [SerializeField] private CinemachineVirtualCamera boss_cam;

    private void Start() 
    {
        virtual_cam = Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera;
        UIManager.Instance.scene_one_boss_stuff.SetActive(false);
    }

    public void TriggerCameraEffect()
    {
        input_reader.DisablePlayer();
        
        UIManager.Instance.player_stuff.SetActive(false);
        UIManager.Instance.scene_one_boss_stuff.SetActive(false);

        boss_cam.gameObject.SetActive(true);
        virtual_cam.gameObject.SetActive(false);
        Invoke("BackToPlayer", 4.0f);
    }

    private void BackToPlayer()
    {
        input_reader.EnablePlayer();
        
        virtual_cam.gameObject.SetActive(true);

        boss_cam.gameObject.SetActive(false);
        Invoke("DelayUIShow", 2);
    }

    private void DelayUIShow()
    {
        UIManager.Instance.player_stuff.SetActive(true);
        UIManager.Instance.scene_one_boss_stuff.SetActive(true);
    }
}
