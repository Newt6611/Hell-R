using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossDied : MonoBehaviour, ISceneOneBoss
{
    private SceneOneBoss boss;
    private string name;
    
    private Vector2 target_pos;
    float time = 5;

    public SceneOneBossDied(SceneOneBoss boss, string name) 
    {
        this.boss = boss;
        this.name = name;
        
    }
    
    public void OnEnter() 
    {
        time = 3;
        boss.animator.Play("died");
    }

    public void OnUpdate()
    {
        Debug.Log(time);
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            PlayDoorDown();
            boss.DestroySelf();
        }
            
    }

    public void OnExit() 
    {

    }

    private void PlayDoorDown()
    {
        boss.door.GetComponent<Animator>().Play("down");
    }

    public string GetName() => name;
}
