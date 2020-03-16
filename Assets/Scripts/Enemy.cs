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
    [SerializeField] float projectileSpeed = 5;
    public float moveSpeed = 0.1f;

    [SerializeField] SpawnConfig spawnConfig;

    [Header("Shooting")]
    GameObject projectile;
    Vector2 direction;
    public Transform targetPosition;
    public bool canShoot = false;
    private float angle;
    public Rigidbody2D rigidbody2D;



    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
    }
}
