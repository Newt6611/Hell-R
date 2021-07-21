using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("ExitGame");
    }

    public void ReadHistory()
    {
        Debug.Log("Read History");
    }

    public void Setting()
    {
        Debug.Log("Setting");
    }

    public void OnSelect(BaseEventData data)
    {

    }
}
