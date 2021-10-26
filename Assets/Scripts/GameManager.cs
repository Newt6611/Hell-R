using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum SceneName 
{
    SceneOne, SceneOneBoss
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance { get { return m_instance; } }

    public SceneName CurrentScene = SceneName.SceneOne;

    private PlayerInput player_input;
    [SerializeField] InputReader input_reader;

    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;
        
        player_input = GetComponent<PlayerInput>();
        player_input.onControlsChanged += OnControlsChanged;
        Debug.Log("current input device : " + player_input.currentControlScheme);
    }

    private void Update() 
    {
    }
    
    public void OnControlsChanged(PlayerInput input)
    {
        Debug.Log("current input device : " + player_input.currentControlScheme);
        input_reader.OnControllerChange();
    }
}
