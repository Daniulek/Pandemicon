using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 15;
    private Rigidbody2D rigidBody2D;
    public float bulletForce = 20f;

    public Animator animator;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.gravityScale = 1;
        animator = GetComponent<Animator>();
        
    }

  

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", CrossPlatformInputManager.GetAxisRaw("Horizontal"));

            moveDir = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0).normalized;
           
    }

    void FixedUpdate()

    {

            Vector2 globalmovedir = (transform.TransformDirection(moveDir));
            rigidBody2D.position += globalmovedir * moveSpeed * Time.fixedDeltaTime;
            

    }



}
