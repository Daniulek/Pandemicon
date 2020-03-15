using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCell : MonoBehaviour
{

    [SerializeField] int health=150;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            sceneLoader = new SceneLoader();
            sceneLoader.LoadGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bacteriophage")
        {
            health -= 10;

        }
    }
}
