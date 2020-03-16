using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCell : MonoBehaviour
{
    float hurtTime = 0.0f;
    float hurtRate = 2f;
    float bonusTime = 60f;
    int multiplier = 1;


    [SerializeField] int health=150;
    //SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {
        AddingHP();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOver();
            //sceneLoader = new SceneLoader();
            //sceneLoader.LoadGameOver();
        }
    }

    private void AddingHP() // HP ACHIEVMENT
    {
        

        if (Time.time > bonusTime)
        {
            
            health += 25 * multiplier;
            bonusTime += 60f;
            Debug.Log(25 * multiplier + " : " + health);
            multiplier += 1;
            
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Bacteriophage")
    //    {
    //        health -= 1;

    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bacteriophage")
        {


            if (Time.time > hurtTime)
            {
                hurtTime = Time.time + hurtRate;
                health -= 1;
            }


        }
    }
}
