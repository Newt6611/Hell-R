using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerState
{
    private Player player;
    private string state_name;
    
    public RunState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    { 
        player.ani.Play("run");
    }

    public void OnUpdate() 
    { 
        if(player.Movement.x == 0)
            player.UpdateState("idle");
    }

    public void OnFixedUpdate() 
    {
        player.Move();
    }

    public void OnLateUpdate() 
    {

    }

    public void OnStateExit() { }

    public string GetStateName() => this.state_name;
}
