using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneOneBoss
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
    string GetName();
}
