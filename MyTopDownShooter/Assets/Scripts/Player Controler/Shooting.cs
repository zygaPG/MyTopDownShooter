using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{

    public LayerMask layerMask;

    public Trail trailPrefab;

    private ObjectPool<Trail> pool;

    public float atackCuldown;
    float atackTime;

    private void Start()
    {
        pool = new ObjectPool<Trail>(() =>{
            Trail trail = Instantiate(trailPrefab);
            trail.shoting = this;
            return trail;
            
        },
        trail =>
        {

            trailPrefab.gameObject.SetActive(true);
            trail.transform.position = transform.position;
            trail.enabled = true;
        },
        trail =>
        {
            trail.enabled = false;
            trailPrefab.gameObject.SetActive(false);
        },
        trail =>
        {
            Destroy(trail.gameObject);
        },
        true,
        10,
        20


        );


    }




    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }


        if(atackTime > 0)
        {
            atackTime -= Time.deltaTime;
        }
    }



    void Fire()
    {
        if (atackTime <= 0)
        {
            atackTime = atackCuldown;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, layerMask))
            {
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().TakeDamage(2);

                    SpawnTrail(hit.point);
                }
            }
        }
        else
        {
            atackTime -= Time.deltaTime;
        }


    }

    void SpawnTrail(Vector3 targetPoint)
    {
        Trail trail                 = pool.Get();
        trail.transform.position    = transform.position;
        trail.targetPoint           = targetPoint;
    }

    public void DestroyTrail(Trail trail)
    {
        pool.Release(trail);
    }
}
