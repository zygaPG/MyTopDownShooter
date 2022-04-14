using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]
    AnimatorControler animatorCotroler;

    [SerializeField]
    Transform playerModel;

    public float moveSpeed = 5;


    void Start()
    {
        rigidBody           = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        rigidBody.velocity = moveDirection * moveSpeed * 60 * Time.fixedDeltaTime;

        
        animatorCotroler.SetAxis(moveDirection);
    }

}
