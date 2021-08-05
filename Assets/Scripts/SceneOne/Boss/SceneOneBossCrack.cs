using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossCrack : ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;

    public SceneOneBossCrack(SceneOneBoss boss, string name)
    {
        this.boss = boss;
        this.name = name;
    }

    public void OnEnter() 
    {
        boss.PlayAnimation("crack");
    }

    public void OnUpdate() { }

    public void OnExit() 
    {
        boss.SetRestTime(3.0f);
    }

    public string GetName() => name;
}
