using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerState
{
    private Player player;
    private string state_name;

    private bool is_jump_down = false;
    
    private float delay_dectect_time;
    private float delay_btw;
    private bool start_dectect;

    public JumpState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    {
        player.ani.Play("jump_up");
        player.rb.AddForce(Vector2.up * player.Jump_Force, ForceMode2D.Impulse);
        
        player.Jumping = true;
        is_jump_down = false;

        delay_dectect_time = 0.1f;
        delay_btw = delay_dectect_time;
        start_dectect = false;
    }

    public void OnUpdate() 
    {
        if(player.rb.velocity.y <= 0 && !is_jump_down)
        {
            is_jump_down = true;
            player.ani.Play("jump_down");
        }

        if(delay_btw <= 0)
            start_dectect = true;
        else
            delay_btw -= Time.deltaTime;
    }

    public void OnFixedUpdate() 
    {
        player.Move();
    }

    public void OnLateUpdate() 
    {
        // Dectect Is Ground
        if(!start_dectect)
            return;

        if(Physics2D.OverlapCircle(player.jump_dectector.position, player.jump_dectector_radius, player.ground_layer))
        {
            if(player.Movement.x == 0)
                player.UpdateState("idle");
            else if(player.Movement.x != 0)
                player.UpdateState("run");
        }
    }

    public void OnStateExit() 
    { 
        player.Jumping = false;
    }

    public string GetStateName() => this.state_name;
}
