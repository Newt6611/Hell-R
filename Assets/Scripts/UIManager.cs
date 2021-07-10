using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    public static UIManager Instance { get { return m_instance; } }


    [SerializeField] public Image healthBar;

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

    public void UpdatePlayerHealthBar()
    {
        healthBar.fillAmount = (float)Player.Instance.Current_Health / (float)Player.Instance.TotalHealth;        
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
}
