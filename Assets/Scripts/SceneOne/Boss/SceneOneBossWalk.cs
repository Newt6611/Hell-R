using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossWalk : ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;
    
    private Vector2 target_pos;

    public SceneOneBossWalk(SceneOneBoss boss, string name) 
    {
        this.boss = boss;
        this.name = name;
    }
    
    public void OnEnter() 
    {
        if(Mathf.Abs(boss.base_pos.x - boss.transform.position.x) > 0.01f)
        {
            Debug.Log("walk bbbbbbbbbbbbbbbbbback");
            boss.PlayAnimation("walkback");
            target_pos = boss.base_pos;
        }
        else
        {
            boss.PlayAnimation("walkforward");
            target_pos = Player.Instance.transform.position;
        }
    }

    public void OnUpdate()
    {
        if(Mathf.Abs(boss.transform.position.x - target_pos.x) <= 0.01f)
        {
            boss.UpdateState("idle");
        }
        else
        {
            if(Physics2D.OverlapCircle(boss.transform.position, boss.SwingRadius - 1.5f, boss.PlayerLayer) && target_pos != boss.base_pos)
            {
                boss.UpdateState("swing");
            }
            else
            {
                boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(target_pos.x, boss.transform.position.y), boss.Speed * Time.deltaTime);
            }
        }

    }

    public void OnExit() 
    {
        target_pos = Vector2.zero;
    }

    public string GetName() => name;
}
