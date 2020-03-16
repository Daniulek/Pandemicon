using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Transform motherCell;
    int dir = 1;
    public float myTransformZ;
    public float autodestruction;





    void Awake()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, autodestruction);
       
    }

    private void Start()
    {
        motherCell = GameObject.FindGameObjectWithTag("MotherCell").GetComponent<Transform>();
        ChangeDirection();
    }




    void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        Vector3 direction = motherCell.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
        direction.Normalize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
    }
}
