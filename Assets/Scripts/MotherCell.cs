using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCell : MonoBehaviour
{
    float hurtTime = 0.0f;
    float hurtRate = 2f;
    float bonusTime = 60f;
    float elapsedTime;
    int multiplier = 1;
    private Animator animator;



    [SerializeField] int health=150;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Health", health);
        elapsedTime = Time.timeSinceLevelLoad;
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
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(enemy);
            }

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Corona"))
            {
                Destroy(enemy);
            }

            FindObjectOfType<SceneLoader>().LoadGameOver();

        }
    }

    private void AddingHP() // HP ACHIEVMENT
    {
        

        if (elapsedTime > bonusTime)
        {
            
            health += 25 * multiplier;
            bonusTime += 60f;
            Debug.Log(25 * multiplier + " : " + health);
            multiplier += 1;
            
        }

    }

 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {


            if (elapsedTime > hurtTime)
            {
                hurtTime = elapsedTime + hurtRate;
                health -= 1;
            }


        }
    }
}
