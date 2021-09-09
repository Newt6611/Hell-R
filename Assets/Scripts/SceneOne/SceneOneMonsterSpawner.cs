using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneMonsterSpawner : MonoBehaviour
{
    public static SceneOneMonsterSpawner Instance { get { return m_instance; } }
    private static SceneOneMonsterSpawner m_instance;
    

    private bool spawn = true;
    [SerializeField] private GameObject dog_pre;
    [SerializeField] private GameObject cat_pre;

    [SerializeField] Transform left_side;
    [SerializeField] Transform right_side;

    private int max_amount = 4;

    private float base_spawn_time;

    private float time_to_spawn_btw;

    private void Awake() 
    {
        if(m_instance != null && m_instance != this)
            Destroy(this);
        else
            m_instance = this;
    }

    public void Start() 
    {
        SceneOneManager.Instance.on_dark_mode += OnDarkMode;
        SceneOneManager.Instance.on_normal_mode += OnNormalMode;
        time_to_spawn_btw = 10;
        base_spawn_time = 10;
    }

    private void Update() 
    {
        Debug.Log(spawn);
        transform.position = Player.Instance.transform.position;
        if(!spawn)
            return;
        if(SceneOneManager.Instance.Mode == SceneOneMode.normal)
        {
            Timer(SceneOneManager.Instance.NormalObjCount);
        }
        else
        {
            Timer(SceneOneManager.Instance.DarkObjCount);
        }
    }

    private void Timer(int enemys_count)
    {
        if(time_to_spawn_btw < 0 && enemys_count <= max_amount)
            Spawn();
        else
            time_to_spawn_btw -= Time.deltaTime;
    }

    private void Spawn()
    {
        time_to_spawn_btw = base_spawn_time - Random.Range(0, 2);

        int index = Random.Range(0, 2);
        GameObject enemy;
        if(index == 0)
            enemy = Instantiate(dog_pre, RandomPos(), Quaternion.identity);
        else
            enemy = Instantiate(cat_pre, RandomPos(), Quaternion.identity);

        enemy.GetComponent<IEnemy>().SetSpawner(this);
        enemy.GetComponent<IEnemy>().SetMode(SceneOneManager.Instance.Mode == SceneOneMode.normal ? false : true);
        
        if(SceneOneManager.Instance.Mode == SceneOneMode.normal)
            SceneOneManager.Instance.RegisterNormalObj(enemy);
        else
            SceneOneManager.Instance.RegisterDarkObj(enemy);
    }

    private Vector2 RandomPos()
    {
        int side = Random.Range(0, 2); // 0-> left; 1-> right
        int range = Random.Range(1, 7);
        Vector2 target;
        if(side == 0)
            target = new Vector2(left_side.position.x + range, left_side.position.y);
        else
            target = new Vector2(right_side.position.x - range, right_side.position.y);
        return target;
    }

    private void OnDarkMode()
    {
        max_amount = 8;
        base_spawn_time = 3.5f;
    }

    private void OnNormalMode()
    {
        max_amount = 2;
        base_spawn_time = 8;
    }

    public void UpdateIsSpawn()
    {
        spawn = !spawn;
    }
}
