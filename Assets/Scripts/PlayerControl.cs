using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Player Movement")]
    public float regularSpeed;
    public float focusSpeed;
    public Rigidbody2D playerRB;
    public GameObject hitbox;

    [Header("Player Shooting")]
    public Transform[] bulletSpawnPointList;
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
        hitbox.SetActive(false);
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
            hitbox.SetActive(true);
        }
        else
        {
            moveSpeed = regularSpeed;
            hitbox.SetActive(false);
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
            for (int i = 0; i < 1; i++)
            {
              Transform bulletSpawnPoint = bulletSpawnPointList[i];
                nextFire = Time.time + fireRate;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                //bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            }
        }
        //Shoot Bombs

    }
}
