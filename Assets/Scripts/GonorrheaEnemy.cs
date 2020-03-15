using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonorrheaEnemy : Enemy
{
    private Transform targetPosition;



    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GameObject.FindGameObjectWithTag("MotherCell").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, Time.deltaTime);
    }
}
