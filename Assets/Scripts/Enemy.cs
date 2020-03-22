using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int scoreValue = 150;
    [SerializeField] float health = 100;
    [SerializeField] float fireRate;
    public float moveSpeed = 0.1f;


    [SerializeField] SpawnConfig spawnConfig;
    [SerializeField] Animator animator;

    [Header("Shooting")]
    GameObject projectile;
    Vector2 direction;
    public Transform targetPosition;
    public bool canShoot = false;
    private float angle;
    public Rigidbody2D rigidbody2D;
    private int countCorona = 0;

    
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX; 



    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        fireRate = 5f;
        targetPosition = GameObject.FindGameObjectWithTag("MotherCell").GetComponent<Transform>();
        
    }


    void Update()
    {
        if (canShoot == true)
        {
            CountDownAndShoot();
        }

    }

    private void CountDownAndShoot()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0) {
            Fire();
            fireRate = 5f;
        }
    }

    private void Fire()
    {
        projectile = spawnConfig.GetEnemyBulletPrefab();
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Borders")
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        animator.SetTrigger("Hit");

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
        if (gameObject.tag == "Corona")
        {
            FindObjectOfType<GameSession>().CountCorona();
        }

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        Destroy(gameObject);

        deathVFX = GameObject.FindGameObjectWithTag("Explosion");
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, 0.3f);
        
    }


}
