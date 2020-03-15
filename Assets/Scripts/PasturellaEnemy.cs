using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasturellaEnemy : MonoBehaviour
{

    public Transform motherCell;

    bool canShoot;
    float fireRate;
    float health = 1;

    Rigidbody2D rigidbody2D;
    Vector2 movement;


    private void Awake()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);

        Vector3 direction = motherCell.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        rigidbody2D.rotation = angle;
        direction.Normalize();
    }


    public void Damage()
    {
        health--;
        if (health == 0)
            Die();


    }

    private void Die()
    {
        Destroy(gameObject);
    } 
}
