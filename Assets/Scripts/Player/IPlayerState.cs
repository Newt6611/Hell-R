using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void OnStateEnter();
    void OnUpdate();
    void OnFixedUpdate();
    void OnLateUpdate();
    void OnStateExit();
    string GetStateName();
}
