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
    public int gunTier;
    public int lives;
    public int bombs;
    public GameObject fei;

    [Header("Player Stats")]
    public GameObject[] playerLives;
    public GameObject[] playerBombs;
    public GameObject[] playerPower;

    private Vector2 moveDirection;
    private float moveSpeed;
    private float nextFire;
    private bool invincible;

    //On Start Values
    private void Start()
    {
        invincible = false;
        moveSpeed = regularSpeed;
        hitbox.SetActive(false);
        gunTier = 1;
        lives = 3;
        bombs = 2;
        playerLives[0].SetActive(true);
        playerLives[1].SetActive(true);
        playerLives[2].SetActive(true);
        playerBombs[0].SetActive(true);
        playerBombs[1].SetActive(true);
        playerPower[0].SetActive(true);
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
            Vector2 current = fei.transform.position;
            Vector2 target = transform.position;
            moveSpeed = focusSpeed;
            hitbox.SetActive(true);
            fei.transform.position = Vector2.MoveTowards(current, target, 0.1f);
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
            for (int i = 0; i < gunTier; i++)
            {
              Transform bulletSpawnPoint = bulletSpawnPointList[i];
                nextFire = Time.time + fireRate;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                //bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            }
        }
        //Shoot Bombs
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Trigger Bomb
            playerBombs[bombs - 1].SetActive(false);
            bombs--;
        }
    }

    public void Death()
    {
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
        else if (invincible == false)
        {
            transform.position = new Vector2(0, -7);
            //Trigger Animation
            playerLives[lives - 1].SetActive(false);
            lives--;
            playerPower[gunTier - 1].SetActive(false);
            gunTier--;
            if (gunTier <= 0)
            {
                gunTier = 1;
                playerPower[0].SetActive(true);
            }
            invincible = true;
        }
        else if (invincible == true)
        {
            for (float i = 0; i <= 4; i += Time.deltaTime)
            {
                invincible = true;
            }
            invincible = false;
        }
    }
}
