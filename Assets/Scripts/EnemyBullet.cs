using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 1;
    private Transform motherCell;
    private Vector2 target;
    

    void Awake()
    {
        motherCell = GameObject.FindGameObjectWithTag("MotherCell").transform;

        target = new Vector2(motherCell.position.x, motherCell.position.y);
       

    }



    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MotherCell") || collision.CompareTag("Player") || collision.CompareTag("Bullet"))
        {
            Object.Destroy(this.gameObject);
        }
    }
}
