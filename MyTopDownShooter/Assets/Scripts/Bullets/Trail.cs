using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using RAndom = UnityEngine.Random;

public class Trail : MonoBehaviour
{
    public Shooting shoting; 

    public Vector3 targetPoint;
    public float speed;

    public float timeToDestroy = 0.4f;
    float currentTimeToDestroy = 0;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, currentTimeToDestroy / timeToDestroy);


        if(currentTimeToDestroy < timeToDestroy)
        {
            currentTimeToDestroy += Time.deltaTime;
        }
        else
        {
            if(shoting)
            shoting.DestroyTrail(this);
            currentTimeToDestroy = 0;
            this.enabled = false;
        }
    }
    

}
