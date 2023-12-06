using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    enum BulletType { Homing, NonHoming }

    [Header("Bullet Stats")]
    public float bulletLife;
    public float bulletRotation;
    public float bulletSpeed;
    public float bulletDamage;
    public bool homing;

    private Vector2 spawnPoint;
    private float timer = 0f;
    private GameObject player;
    private Vector2 lastKnownPlayerPosition;
    private float playerX;
    private float playerY;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        player = GameObject.FindGameObjectWithTag("Player");
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
            Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);

        if (gameObject.transform.position.y < -10 || gameObject.transform.position.y > 10 || gameObject.transform.position.x < -11 || gameObject.transform.position.x > 11)
            Destroy(gameObject);
    }

    private Vector2 Movement(float timer)
    {
        float x;
        float y;

        if (homing == true)
        {
            x = timer * (bulletSpeed / 5) * playerX;
            y = timer * (bulletSpeed / 5) * playerY;
        }
        else
        {
            x = timer * bulletSpeed * transform.right.x;
            y = timer * bulletSpeed * transform.right.y;
        }

        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}
