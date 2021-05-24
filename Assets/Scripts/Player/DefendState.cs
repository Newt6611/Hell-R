using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendState : IPlayerState
{
    private Player player;
    private string state_name;
    
    public DefendState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    {
        player.ani.Play("defend");
        player.StopMove();
        player.Defending = true;
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
        player.StartMove();
        player.Defending = false;
    }

    public string GetStateName() => this.state_name;
}
