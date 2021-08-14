using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void TakeDamage(int d);
    void SetSpawner(SceneOneMonsterSpawner spawner);
    void SetMode(bool is_dark);
}
