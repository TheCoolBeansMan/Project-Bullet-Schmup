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
    private GameObject player;
    private Vector2 lastKnownPlayerPosition;
    private float playerX;
    private float playerY;
    private Vector2 spawnPoint;


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
    public Collider2D grazeZone;
    public Collider2D deathZone;

    public Renderer rend;
    public GameObject scoreTracker;
    public bool shootingEnabled;

    private Vector2 moveDirection;
    private float moveSpeed;
    private float nextFire;
    private Color c;
    private GameObject[] bulletsOnScreen;
    private bool hitOnce;
    private Vector2 pos;

    //On Start Values
    private void Start()
    {
        shootingEnabled = true;
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        player = GameObject.FindGameObjectWithTag("Player");
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
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
        c = rend.material.color;
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
        if (transform.position.y <= -9)
        {
            pos.x = transform.position.x;
            pos.y = -9f;
            transform.position = pos;
        }
        if (transform.position.y >= 9f)
        {
            pos.x = transform.position.x;
            pos.y = 9f;
            transform.position = pos;
        }
        if (transform.position.x <= -10.5f)
        {
            pos.x = -10.5f;
            pos.y = transform.position.y;
            transform.position = pos;
        }
        if (transform.position.x >= 10f)
        {
            pos.x = 10f;
            pos.y = transform.position.y;
            transform.position = pos;
        }
    }

    //Manages Shooting and Bombs
    private void Shooting()
    {
        if (shootingEnabled == true)
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
                if (bombs > 0)
                {
                    scoreTracker.GetComponent<MeterManager>().score += 001000;
                    //Trigger Animation
                    bulletsOnScreen = GameObject.FindGameObjectsWithTag("RedBullet");
                    for (int i = 0; i < bulletsOnScreen.Length; i++)
                    {
                        Destroy(bulletsOnScreen[i]);
                    }
                    bulletsOnScreen = GameObject.FindGameObjectsWithTag("BlueBullet");
                    for (int i = 0; i < bulletsOnScreen.Length; i++)
                    {
                        Destroy(bulletsOnScreen[i]);
                    }
                    bulletsOnScreen = GameObject.FindGameObjectsWithTag("BlackBullet");
                    for (int i = 0; i < bulletsOnScreen.Length; i++)
                    {
                        Destroy(bulletsOnScreen[i]);
                    }
                    playerBombs[bombs - 1].SetActive(false);
                    bombs--;
                }
            }
        }
    }

    public void SetLastKnownPlayerPosition(Vector2 position)
    {
        lastKnownPlayerPosition = player.transform.position;
    }

    public void Death()
    {
        if (hitOnce == false)
        {
            if (lives <= 0)
            {
                Destroy(gameObject);
            }

            transform.position = new Vector2(0, -7);

            playerLives[lives - 1].SetActive(false);
            lives--;
            playerPower[gunTier - 1].SetActive(false);
            gunTier--;
            hitOnce = true;

            if (gunTier <= 0)
            {
                gunTier = 1;
                playerPower[0].SetActive(true);
            }
        }
    }

    IEnumerator GetInvulnerable()
    {
        grazeZone.enabled = false;
        deathZone.enabled = false;
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3);
        grazeZone.enabled = true;
        deathZone.enabled = true;
        c.a = 1f;
        rend.material.color = c;
        hitOnce = false;
    }
}
