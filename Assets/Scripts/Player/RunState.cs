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
        player.audio_source.clip = player.walk;
        player.audio_source.volume = 0.1f;
        player.audio_source.Play();
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

    public void OnStateExit() 
    {
        player.audio_source.Stop();
        player.audio_source.volume = 1f;
    }

    public string GetStateName() => this.state_name;
}
