using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using RAndom = UnityEngine.Random;

public class Trail : MonoBehaviour
{
    public Shooting shoting; 
    //public float speed;

    public float timeToDestroy = 0.4f;
    float currentTimeToDestroy = 0;

    private void Update()
    {
        
       // transform.position += transform.forward * speed * Time.deltaTime;

        if (currentTimeToDestroy >= timeToDestroy)
        {
            if (shoting)
                shoting.DestroyTrail(this);

            currentTimeToDestroy = 0;
            this.enabled = false;
        }
        else
        {
            currentTimeToDestroy += Time.deltaTime;
        }
    }
    

}
