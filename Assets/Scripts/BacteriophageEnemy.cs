﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriophageEnemy : Enemy
{
   //private Transform targetPosition;
    //Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        targetPosition = GameObject.FindGameObjectWithTag("MotherCell").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 direction = targetPosition.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rigidbody2D.rotation = angle;
        direction.Normalize();

        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Die();
        }
    
    }
}
