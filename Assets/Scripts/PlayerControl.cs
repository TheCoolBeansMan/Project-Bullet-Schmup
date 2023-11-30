using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Movement")]
    public float regularSpeed;
    public float focusSpeed;
    public Rigidbody2D playerRB;

    [Header("Player Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate;

    private Vector2 moveDirection;
    private float moveSpeed;
    private float nextFire;

    //On Start Values
    private void Start()
    {
        moveSpeed = regularSpeed;
    }
    //Update Once per Frame, Use for Proccessing Inputs
    private void Update()
    {
        ProcessInputs();
        Shooting();
    }

    //Updates every fixed framerate frame, Use for Physics Calculations
    private void FixedUpdate()
    {
        Move();
    }

    //Handles Hitboxes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BlackEnemyBullet")
        {
            //Trigger Graze Sound and Visuals
            //Increase Color Graze Meter
        }
        if (collision.tag == "RedEnemyBullet")
        {
            //Trigger Graze Sound and Visuals
            //Increase Color Graze Meter
        }
        if (collision.tag == "BlueEnemyBullet")
        {
            //Trigger Graze Sound and Visuals
            //Increase Color Graze Meter
        }

        if (collision.tag == "EnemyHitbox")
        {
            //Call Death Method
        }
    }

    private void ProcessInputs()
    {
        //Calculates Standard Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        //Calculates Focus mode on shift press
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = focusSpeed;
        }
        else
        {
            moveSpeed = regularSpeed;
        }
    }

    private void Move()
    {
        //Moves Player
        playerRB.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    //Manages Shooting and Bombs
    private void Shooting()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            //bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
        //Shoot Bombs
    }

    //Manages current meter status aswell as appropriate conditions
    private void StatHandler()
    {
        //Manage Meter Updates
        //Manage Life Count
        //Manage Bomb Count
        //Manage Shot Tier
        //Update Meter UI, Life and Bomb Icons
    }

    //Handles Player Death
    private void Death()
    {
        //Trigger Player Death Sound
        //Kill Player
        //Respawn Player
        //Allow for Bomb Death Condition
    }
}
