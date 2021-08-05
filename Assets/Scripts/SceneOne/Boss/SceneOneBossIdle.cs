using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossIdle : ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;

    private float chane_time = 10.0f;
    private float chane_time_btw;

    private float rest_time_btw;

    public SceneOneBossIdle(SceneOneBoss boss, string name)
    {
        this.boss = boss;
        this.name = name;
    }

    public void OnEnter() 
    {
        chane_time_btw = chane_time; // Change Idle Type Every 5 Seconds, If No Need To Attack Or Do Anythings Else.

        rest_time_btw = boss.RestTime;

        // Random Play Idle Animation -> there's three animation type
        int i = Random.Range(0, 3);
        string idle_name = "idle" + i;
        boss.PlayAnimation(idle_name);
    }

    public void OnUpdate()
    {
        if(chane_time_btw <= 0)
            boss.UpdateState(name);
        chane_time_btw -= Time.deltaTime;

        

        if(rest_time_btw > 0)
        {
            rest_time_btw -= Time.deltaTime;
            return;
        }
        


        if(Physics2D.OverlapCircle(boss.transform.position, boss.SwingRadius, boss.PlayerLayer))
        {
            boss.UpdateState("swing");
        }
        else if(Physics2D.OverlapCircle(boss.transform.position, boss.CrackRadius, boss.PlayerLayer))
        {
            int index = Random.Range(0, 2);
            if(index == 0)
                boss.UpdateState("crack");
            else
                boss.UpdateState("walk");
        }
        else if(Physics2D.OverlapCircle(boss.transform.position, boss.FireBallRadius, boss.PlayerLayer))
        {
            boss.UpdateState("fireball");
        }
    }

    public void OnExit() 
    {

    }

    public string GetName() => name;
}
