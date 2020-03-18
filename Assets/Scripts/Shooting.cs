using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;


    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Shoot"))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
