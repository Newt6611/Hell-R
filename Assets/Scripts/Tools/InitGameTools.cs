using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Check GameTools Is Using Or Not
public class InitGameTools : MonoBehaviour
{
    private string game_tool_scene_name = "GameTools";
    private string audio_scene_name = "AudioScene";

    private void Awake()
    {
        bool has_tool = false;
        bool has_audio = false;

        for(int i=0; i<SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if(scene.name == game_tool_scene_name && !has_tool)
                has_tool = true;
            if(scene.name == audio_scene_name && !has_audio)
                has_audio = true;
        }

        if(SceneManager.GetSceneAt(0).name == "StartMenu" && !has_audio)
        {
            SceneManager.LoadScene(audio_scene_name, LoadSceneMode.Additive);
        }
        else if(SceneManager.GetSceneAt(0).name != "StartMenu" && (!has_tool || !has_audio))
        {
            if(!has_audio)
                SceneManager.LoadScene(audio_scene_name, LoadSceneMode.Additive);
            if(!has_tool)
                SceneManager.LoadScene(game_tool_scene_name, LoadSceneMode.Additive);
        }
    }
}
