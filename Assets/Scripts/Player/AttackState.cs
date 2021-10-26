using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IPlayerState
{
    private Player player;
    private string state_name;
    
    public AttackState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    {
        player.audio_source.PlayOneShot(player.attack, 0.5f);

        if(Physics2D.OverlapCircle(player.jump_dectector.position, player.jump_dectector_radius, player.ground_layer))
            player.ani.Play("attack");
        else
            player.ani.Play("attack2");
    }

    public void OnUpdate() { }

    public void OnFixedUpdate() 
    {
        player.Move();
    }

    public void OnLateUpdate() { }

    public void OnStateExit() 
    {
        player.Attacking = false;
    }

    public string GetStateName() => this.state_name;
}
