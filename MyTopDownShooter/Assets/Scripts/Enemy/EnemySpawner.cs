using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTarget;

    public int maxEnemys = 5;
    public int maxMaxEnemys = 150;
    public int enemysAmount = 0;

    public float enemyTimeToIncrease = 5;
    float currentTime;



    public Enemy enemyPrefab;
    private ObjectPool<Enemy> poolEnemy;

    private void Start()
    {
        poolEnemy = new ObjectPool<Enemy>(() => {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.player = playerTarget;
            enemy.spawner = this;
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;

            return enemy;

        },
        enemy =>
        {
            enemy.gameObject.SetActive(true);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            
        },
        enemy =>
        {
            enemy.gameObject.SetActive(false);
        },
        enemy =>
        {
            Destroy(enemy.gameObject);
        },
        true,
        maxEnemys,
        maxMaxEnemys


        );


    }


    private void FixedUpdate()
    {
        if(enemysAmount < maxEnemys)
        {
            ChangePosition();
            SpawnEnemy();
            enemysAmount++;
        }

        if(currentTime <= 0)
        {
            if (maxEnemys <= maxMaxEnemys)
            {
                maxEnemys++;
                currentTime = enemyTimeToIncrease;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }


    void SpawnEnemy()
    {
        poolEnemy.Get();
    }


    /// <summary>
    /// destroy enemy
    /// </summary>
    /// <param name="curEnemy"></param>
    public void KillEnemy(Enemy curEnemy)
    {
        enemysAmount--;
        poolEnemy.Release(curEnemy);
    }

    
    /// <summary>
    /// random change spawner position 
    /// </summary>
    public void ChangePosition()
    {
        if(Random.Range(-1f, 1f) > 0)
        {
            float randomZ = Random.Range(-9, 9);
            if (Random.Range(-1f, 1f) > 0)
            {
                //left
                transform.localPosition = new Vector3(-16, 0, randomZ);
            }
            else
            {
                //right
                transform.localPosition = new Vector3(16, 0, randomZ);
            }

        }
        else
        {
            float randomX = Random.Range(-16, 16);
            if (Random.Range(-1f, 1f) > 0)
            {
                //left
                transform.localPosition = new Vector3(9, 0, randomX);
            }
            else
            {
                //right
                transform.localPosition = new Vector3(9, 0, randomX);
            }
        }


    }


    
}
