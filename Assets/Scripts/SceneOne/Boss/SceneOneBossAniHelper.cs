using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneBossAniHelper : MonoBehaviour
{
    private SceneOneBoss boss;
    [SerializeField] private FireBall fire_ball_pre;
    
    [SerializeField] private RockSpawner rock_spawner;

    private GameFeel game_feel;

    private float start_time_scale;
    private float start_fixed_deltatime;

    private void Start()
    {
        boss = GetComponentInParent<SceneOneBoss>();
        game_feel = GetComponent<GameFeel>();

        start_time_scale = Time.timeScale;
        start_fixed_deltatime = Time.fixedDeltaTime;
    }

    // For Animation Call
    public void EndAttackState()
    {
        if(Mathf.Abs(boss.base_pos.x - boss.transform.position.x) > 0.1f)
            boss.UpdateState("walk");
        else
            boss.UpdateState("idle");
    }

    public void ShootFireBall()
    {
        FireBall fireball = Instantiate(fire_ball_pre, boss.mouse_pos.position, Quaternion.identity);
        fireball.fly_pos = boss.fireball_fly_pos;
        fireball.boss_pos = boss.transform;
        Invoke("Destroy", 8f);
    }

    public void SwingAttack()
    {
        if(Physics2D.OverlapCircle(boss.swing_pos.position, boss.SwingAttackRadius, boss.PlayerLayer))
        {
            Player.Instance.TakeDamage(boss.transform, 1);
            UIManager.Instance.animator.Play("slash");
            game_feel.StopScreen(0.2f);
            game_feel.ShakeCamera(7, 1f);
        }
    }

    public void StartCrack()
    {
        rock_spawner.StartRock();
        game_feel.StopScreen(0.2f);
        game_feel.ShakeCamera(7, 2f);
    }

    private void DestoryObj() 
    {
        if(this.gameObject != null)
            Destroy(this.gameObject);
    }

    
}
