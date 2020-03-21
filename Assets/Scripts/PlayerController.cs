using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 10;
    private Rigidbody2D rigidBody2D;
    AudioSource audioSrc;
    bool isMoving = false;

  


    public Animator animator;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.gravityScale = 1;
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
        

    }

  

    void Update()
    {
        GetComponent<PlayerController>().moveSpeed = FindObjectOfType<GameSession>().GetMS();
        animator.SetFloat("Horizontal", CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        moveDir = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0).normalized;

        if (moveDir.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
            else
            {
                audioSrc.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 globalmovedir = (transform.TransformDirection(moveDir));
        rigidBody2D.position += globalmovedir * moveSpeed * Time.fixedDeltaTime;



    }



}
