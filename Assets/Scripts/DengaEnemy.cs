using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DengaEnemy : Enemy
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    

    // Start is called before the first frame update
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();

    }

    void calculateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * moveSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }

        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }
}
