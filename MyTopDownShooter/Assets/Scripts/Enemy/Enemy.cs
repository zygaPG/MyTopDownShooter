using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rigidBody;

    public EnemySpawner spawner;

    public Transform player;

    public float maxHp;
    float currentHp;

    public float moveSpeed;
    public float timeBetweenLooking;
    float currentLookingTime;

    private void Start()
    {
        currentHp = maxHp;
        rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        rigidBody.velocity = transform.forward * moveSpeed * 60 * Time.fixedDeltaTime;

        if(currentLookingTime < 0)
        {
            currentLookingTime = timeBetweenLooking;
            transform.LookAt(player);

            if (Vector3.Distance(transform.position, player.position) > 22)
            {
                TakeDamage(500);
            }
        }
        else
        {
            currentLookingTime -= Time.deltaTime;
        }
    }



    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            spawner.KillEnemy(this);
        }
    }

    private void OnEnable()
    {
        currentHp = maxHp;
    }
}
