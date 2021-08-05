using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossFireBall : ISceneOneBoss 
{
    private SceneOneBoss boss;
    private string name;

    public SceneOneBossFireBall(SceneOneBoss boss, string name)
    {
        this.boss = boss;
        this.name = name;
    }

    public void OnEnter() 
    {
        // Boss Helper
        boss.PlayAnimation("fireball");
    }

    public void OnUpdate() { }

    public void OnExit() 
    { 
        boss.SetRestTime(4f);
    }

    public string GetName() => name;
}
