using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneObjRegister : MonoBehaviour
{
    public bool is_dark;

    private void Start() 
    {
        if(is_dark)
            SceneOneManager.Instance.RegisterDarkObj(gameObject);
        else
            SceneOneManager.Instance.RegisterNormalObj(gameObject);
    }

    private void OnDestroy()
    {
        if(is_dark)
            SceneOneManager.Instance.RemoveDarkObj(gameObject);
        else
            SceneOneManager.Instance.RemoveNormalObj(gameObject);
    }
}
