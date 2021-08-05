using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneOneMode {
    normal, dark
}

public class SceneOneManager : MonoBehaviour
{
    private static SceneOneManager m_instance;
    public static SceneOneManager Instance { get { return m_instance; } }

    private SceneOneMode mode;
    public SceneOneMode Mode { get { return mode; } }

    [SerializeField] private Sprite normal_corridor;
    [SerializeField] private Sprite dark_corridor;


    [SerializeField] private Sprite normal_classroom;
    [SerializeField] private Sprite normal_chair;

    [SerializeField] private Sprite dark_classroom;
    [SerializeField] private Sprite dark_chair;




    [SerializeField] private List<SpriteRenderer> corridors;
    [SerializeField] private SpriteRenderer classroom;
    [SerializeField] private SpriteRenderer classroom_chair;

    private List<GameObject> dark_objs;
    private List<GameObject> normal_objs;

    public void Awake()
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;
        dark_objs = new List<GameObject>();
        normal_objs = new List<GameObject>();
    }

    private void Start() 
    {
        mode = SceneOneMode.normal;
    }


    public void RegistDarkObj(GameObject obj) 
    {
        dark_objs.Add(obj);
    }

    public void RegestNormalObj(GameObject obj)
    {
        normal_objs.Add(obj);
    }

    public void RemoveDarkObj(GameObject obj) 
    {
        dark_objs.Remove(obj);
    }

    public void RemoveNormalObj(GameObject obj) 
    {
        normal_objs.Remove(obj);
    }


    public void StartModeChanging()
    {
        Camera.main.GetComponent<GameFeel>().ShakeCamera(20.0f, 5.0f);
    }

    public void UpdateCorridor() 
    {
        switch(mode)
        {
            case SceneOneMode.normal:
                ToDark();
                break;
            case SceneOneMode.dark:
                ToNormal();
                break;
        }
    }

    private void ToNormal()
    {
        foreach(SpriteRenderer renderer in corridors)
            renderer.sprite = normal_corridor;

        classroom.sprite = normal_classroom;
        classroom_chair.sprite = normal_chair;

        // update objs
        foreach(GameObject obj in normal_objs)
            obj.SetActive(true);
        
        foreach(GameObject obj in dark_objs)
            obj.SetActive(false);

        mode = SceneOneMode.normal;
    }

    private void ToDark()
    {
        foreach(SpriteRenderer renderer in corridors)
            renderer.sprite = dark_corridor;

        classroom.sprite = dark_classroom;
        classroom_chair.sprite = dark_chair;
        
        // update objs
        foreach(GameObject obj in dark_objs)
            obj.SetActive(true);
        
        foreach(GameObject obj in normal_objs)
            obj.SetActive(false);

        mode = SceneOneMode.dark;
    }

    
}
