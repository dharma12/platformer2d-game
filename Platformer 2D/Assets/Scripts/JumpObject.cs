using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour, IObjectType, IInteracable
{
    public ObjectType ObjectType => ObjectType.InteracableObject;

    private Rigidbody2D jumpObjectRigidbody;
    private int jumpForce = 5;
    [SerializeField] private bool isGrounded;
    public RaycastHit2D hit;
    private void Start()
    {
        jumpObjectRigidbody = gameObject.GetComponent<Rigidbody2D>();

        isGrounded = true;      
    }

    public void CheckIfInteract()
    {
        Jump();
    }

    private void Jump()
    {
        if (isGrounded == true)
        {
            jumpObjectRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = !isGrounded;
        }
        
        //Debug.Log("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
