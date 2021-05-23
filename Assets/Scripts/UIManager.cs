using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;
    public static UIManager Instance { get { return m_instance; } }

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
