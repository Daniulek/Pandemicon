using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 10;
    private Rigidbody2D rigidBody2D;

    //[SerializeField] AudioClip runSound;
    //[SerializeField] [Range(0, 1)] float runSoundVolume = 0.75f; 


    public Animator animator;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.gravityScale = 1;
        animator = GetComponent<Animator>();
        

    }

  

    void Update()
    {
        GetComponent<PlayerController>().moveSpeed = FindObjectOfType<GameSession>().GetMS();
        animator.SetFloat("Horizontal", CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        moveDir = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0).normalized;
    }

    void FixedUpdate()
    {
        Vector2 globalmovedir = (transform.TransformDirection(moveDir));
        rigidBody2D.position += globalmovedir * moveSpeed * Time.fixedDeltaTime;
        //AudioSource.PlayClipAtPoint(runSound, Camera.main.transform.position, runSoundVolume);
    }



}
