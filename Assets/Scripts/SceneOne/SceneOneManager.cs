using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public enum SceneOneMode {
    normal, dark
}

public class SceneOneManager : MonoBehaviour
{
    private static SceneOneManager m_instance;
    public static SceneOneManager Instance { get { return m_instance; } }

    public event Action on_dark_mode;
    public event Action on_normal_mode;

    // Image Effects
    [SerializeField] private Light2D global_light;
    [SerializeField] private Volume volume;
    private Bloom bloom;
    private Vignette vignette;
    private ChromaticAberration chromatic_aberration;
    /////////////////////

    // Player ///////
    public float Total_Hate_Value;
    public float Current_Hate_Value;
    ////////////////

    [SerializeField] private SceneOneMode mode;
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


    public int NormalObjCount { get { return normal_obj.Count; } }
    public int DarkObjCount { get { return dark_obj.Count; } }
    private List<GameObject> normal_obj;
    private List<GameObject> dark_obj;

    public void Awake()
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;

        normal_obj = new List<GameObject>();
        dark_obj = new List<GameObject>();
    }

    private void Start() 
    {
        mode = SceneOneMode.normal;

        Total_Hate_Value = 100;
        Current_Hate_Value = 0;

        volume.profile.TryGet(out bloom);
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromatic_aberration);

        if(mode == SceneOneMode.normal)
            ToNormal();
        else
            ToDark();
    }

    public void RegisterNormalObj(GameObject obj) => normal_obj.Add(obj);

    public void RemoveNormalObj(GameObject obj) => normal_obj.Remove(obj);

    public void RegisterDarkObj(GameObject obj) => dark_obj.Add(obj);

    public void RemoveDarkObj(GameObject obj) => dark_obj.Remove(obj);

    private void Update() 
    {
        /// Controlling HateValue With SceneMode
        if(mode == SceneOneMode.normal)
        {
            if(Current_Hate_Value < 100)
            {
                Current_Hate_Value += 3 * Time.deltaTime;
                UIManager.Instance.UpdateHateValue();
            }
            else if(Current_Hate_Value >= 100)
            {
                UIManager.Instance.animator.Play("fade5s");
            }
        }
        else if(mode == SceneOneMode.dark)
        {
            if(Current_Hate_Value > 10)
            {
                Current_Hate_Value -= 3 * Time.deltaTime;
                UIManager.Instance.UpdateHateValue();
            }
            else if(Current_Hate_Value <= 10)
            {
                UIManager.Instance.animator.Play("fade5s");
            }
        }
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
        mode = SceneOneMode.normal;
        on_normal_mode?.Invoke();

        // update light
        global_light.intensity = 1;
        bloom.intensity.value = 0f;
        vignette.active = false;
        chromatic_aberration.active = false;
        
        // update corridors
        foreach(SpriteRenderer renderer in corridors)
            renderer.sprite = normal_corridor;

        // update animals
        foreach(GameObject obj in normal_obj)
            obj.SetActive(true);

        foreach(GameObject obj in dark_obj)
            obj.SetActive(false);

        classroom.sprite = normal_classroom;
        classroom_chair.sprite = normal_chair;
        
        Current_Hate_Value = 0;
    }

    private void ToDark()
    {
        mode = SceneOneMode.dark;
        on_dark_mode?.Invoke();

        // update light
        global_light.intensity = 0.4f;
        bloom.intensity.value = 1.0f;
        vignette.active = true;
        chromatic_aberration.active = true;

        // update corridors
        foreach(SpriteRenderer renderer in corridors)
            renderer.sprite = dark_corridor;

        // update animals
        foreach(GameObject obj in dark_obj)
            obj.SetActive(true);

        foreach(GameObject obj in normal_obj)
            obj.SetActive(false);

        classroom.sprite = dark_classroom;
        classroom_chair.sprite = dark_chair;
    }
}
