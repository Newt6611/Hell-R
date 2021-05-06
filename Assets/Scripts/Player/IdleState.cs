using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    private Player player;
    private string state_name;
    
    public IdleState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    {
        player.ani.Play("idle");
        player.UpdateState("idle");
    }

    public void OnUpdate() 
    {

    }

    public void OnFixedUpdate() 
    {
        player.Move();
    }

    public void OnLateUpdate() 
    {

    }

    public void OnStateExit() 
    {

    }

    public string GetStateName() => this.state_name;
}
