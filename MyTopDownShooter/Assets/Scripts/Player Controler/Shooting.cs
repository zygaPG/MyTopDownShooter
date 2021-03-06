using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooting : MonoBehaviour
{

    public float damage;

    public LayerMask layerMask;

    public Trail trailPrefab;

    private ObjectPool<Trail> pool;

    public float atackCuldown;
    float atackTime;

    private void Start()
    {
        pool = new ObjectPool<Trail>(() =>{
            Trail trail = Instantiate(trailPrefab);
           // trail.transform.position = transform.position;
            trail.transform.LookAt(transform);

            trail.shoting = this;
            return trail; 
        },
        trail =>
        {

            trail.gameObject.SetActive(true);
            //trail.transform.position = transform.position;
            trail.transform.LookAt(transform);
            trail.enabled = true;
        },
        trail =>
        {
            trail.enabled = false;
            trail.gameObject.SetActive(false);
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
                    SpawnTrail(hit.point);
                    hit.transform.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        else
        {
            atackTime -= Time.deltaTime;
        }
    }

    void SpawnTrail(Vector3 targetPosition)
    {
       Trail newTrail = pool.Get();
        newTrail.transform.position = targetPosition;
    }

    public void DestroyTrail(Trail trail)
    {
        pool.Release(trail);
    }
}
