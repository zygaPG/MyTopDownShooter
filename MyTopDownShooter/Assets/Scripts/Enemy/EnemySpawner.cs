using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public Transform playerTarget;

    public int maxEnemy = 5;
    public int enemyAmount = 0;
    public int enemyIncrease = 1;
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
        50,
        80


        );


    }


    private void FixedUpdate()
    {
        if(enemyAmount < maxEnemy)
        {
            ChangePosition();
            SpawnEnemy();
            enemyAmount++;
        }

        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            maxEnemy++;
            currentTime = enemyTimeToIncrease;
        }
    }


    void SpawnEnemy()
    {
        poolEnemy.Get();
    }

    public void KillEnemy(Enemy curEnemy)
    {
        enemyAmount--;
        poolEnemy.Release(curEnemy);
    }

    

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
