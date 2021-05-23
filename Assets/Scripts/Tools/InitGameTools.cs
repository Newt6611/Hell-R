using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Check GameTools Is Using Or Not
public class InitGameTools : MonoBehaviour
{
    private string game_tool_scene_name = "GameTools";

    private void Awake()
    {
        for(int i=0; i<SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if(scene.name == game_tool_scene_name)
                return;
        }

        SceneManager.LoadScene(game_tool_scene_name, LoadSceneMode.Additive);
    }
}
