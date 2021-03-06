﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    public AudioSource gunshot;
    
    // Start is called before the first frame update
    void Start()
    {
        gunshot.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                gunshot.Play();
            }
        }
        else
        {
            if (shotCounter <= 0)
            {
                shotCounter = 0;
            }
            else
            {
                shotCounter -= Time.deltaTime;
            }
        }
    }
}
