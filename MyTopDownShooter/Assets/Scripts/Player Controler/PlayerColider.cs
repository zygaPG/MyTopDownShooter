using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour
{
    [SerializeField]
    LeveManager lvlManager;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<Enemy>().TakeDamage(500);
            lvlManager.PlayerDead();
            gameObject.SetActive(false);
        }
    }
}
