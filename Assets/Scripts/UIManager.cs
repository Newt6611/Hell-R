﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    public static UIManager Instance { get { return m_instance; } }

    public Image StaminaBar { get { return staminaBar; } }

    [SerializeField] private Image healthBar;
    [SerializeField] private Image staminaBar;


    public GameObject player_stuff;

    public GameObject scene_one_boss_stuff;
    public Image scene_one_boss_healthBar;

    public Animator animator { get { return ani; } }
    private Animator ani;

    // For Player Transition In Same Scene
    private Vector2 next_spot;

    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        ani = GetComponent<Animator>();
    }

    private void Start() 
    {
        UpdatePlayerHealthBar();
    }

    private void Update()
    {
        if(staminaBar.fillAmount < 1)
            staminaBar.fillAmount += 0.0005f;
    

        if(Keyboard.current.gKey.wasPressedThisFrame)
        {
            ani.Play("fade5s");
            
        }
    }

    public void UpdatePlayerHealthBar()
    {
        healthBar.fillAmount = (float)Player.Instance.Current_Health / (float)Player.Instance.TotalHealth;        
    }

    public void ReduceStamina(float percentage)
    {
        staminaBar.fillAmount -= percentage;
    }

    public void Fade(Vector2 next_position) 
    {
        next_spot = next_position;
        ani.Play("fade");
    }

    private void SendPlayerToNextSpot()
    {
        Player.Instance.transform.position = next_spot;
    }


    // SceneOne 
    public void SceneOneStartShaking()
    {
        Debug.Log("g");
        SceneOneManager.Instance.StartModeChanging();
    }

    public void SceneOneUpdateCorridor()
    {
        SceneOneManager.Instance.UpdateCorridor();
    }
}
