using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitedState : MonoBehaviour, IPlayerState
{
    private Player player;
    private string state_name;
    
    public HitedState(string state_name, Player player)
    {
        this.state_name = state_name;
        this.player = player;
    }

    public void OnStateEnter() 
    {
        player.ani.Play("hited");

        if(player.Current_Health <= 0)
            Debug.Log("Dead !");
        UIManager.Instance.UpdatePlayerHealthBar();

        player.game_feel.StopScreen(0.1f);
        player.game_feel.ShakeCamera(5, 0.2f);
        player.sprite_renderer.color = Color.red;
    }

    public void OnUpdate() { }

    public void OnFixedUpdate() { }

    public void OnLateUpdate() { }

    public void OnStateExit() { }

    public string GetStateName() => this.state_name;
}
