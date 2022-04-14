using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rigidBody;

    public Transform player;

    public float moveSpeed;
    public float timeBetweenLooking;
    float currentLookingTime;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        rigidBody.velocity = transform.forward * moveSpeed * 60 * Time.fixedDeltaTime;

        if(currentLookingTime > 0)
        {
            currentLookingTime -= Time.deltaTime;
        }
        else
        {
            currentLookingTime = timeBetweenLooking;
            transform.LookAt(player);
        }
    }







    public void TakeDamage(float damage)
    {
        Debug.Log("i teake damage: "+ damage);
    }
}
