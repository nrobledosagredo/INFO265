﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public GameObject playerObject;

    public float fireRate = 1.0f;
    private float nextFire = 1.0f;

    //public Animator anim;

    AudioSource bulletAudio;
    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ThirdPersonCharacterController Player = playerObject.GetComponent<ThirdPersonCharacterController>();
        if (Input.GetMouseButtonDown(1) & Player.Mana > 0 & Time.time > nextFire)
        {
            bulletAudio.Play();

            //Shoot
            nextFire = Time.time + fireRate;

            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = transform.position + transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;

            Player.Mana = Player.Mana - 30f;
        }
    }
}