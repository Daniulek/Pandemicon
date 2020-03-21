using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherCell : MonoBehaviour
{
    float hurtTime = 0.0f;
    float hurtRate = 2f;
    float bonusTime = 60f;
    float elapsedTime;
    public int multiplier = 1;
    private Animator animator;
    private Animator achievAnimHP;
    private GameObject animPrefab;

    [SerializeField] AudioClip bonusHPSound;
    [SerializeField] [Range(0, 1)] float bonusHPSoundVolume = 0.75f;


    public int health=150;
    

    
    void Start()
    {
        animator = GetComponent<Animator>();
        achievAnimHP = GameObject.FindGameObjectWithTag("AchievHP").GetComponent<Animator>();

    }

    
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
        ClearScene();
    }

    private void ClearScene()
    {
        if (health <= 0)
        {

            
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
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
            achievAnimHP.SetTrigger("start");
            multiplier += 1;

            AudioSource.PlayClipAtPoint(bonusHPSound, Camera.main.transform.position, bonusHPSoundVolume);

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
