using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rigidbody;
    int dir = 1;
    public float myTransformZ;
    public float autodestruction;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, autodestruction);

    }

    public void ChangeDirection()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = new Vector2(0,12*dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage();
            Destroy(this.gameObject);

        }*/
    }
}
