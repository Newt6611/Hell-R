using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossRoar : ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;

    public SceneOneBossRoar(SceneOneBoss boss, string name)
    {
        this.boss = boss;
        this.name = name;
    }

    public void OnEnter() 
    {
        boss.PlayAnimation("roar");
    }

    public void OnUpdate() { }

    public void OnExit() 
    {
        boss.SetRestTime(4.0f);
    }

    public string GetName() => name;
}
