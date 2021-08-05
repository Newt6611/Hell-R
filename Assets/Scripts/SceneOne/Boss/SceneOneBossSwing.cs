using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossSwing : ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;

    public SceneOneBossSwing(SceneOneBoss boss, string name) 
    {
        this.boss = boss;
        this.name = name;
    }
    
    public void OnEnter() 
    {
        boss.PlayAnimation("swing");
    }

    public void OnUpdate() { }

    public void OnExit() 
    {
        boss.SetRestTime(3f);
    }

    public string GetName() => name;
}
