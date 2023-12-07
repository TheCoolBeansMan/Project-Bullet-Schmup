using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, Antispin }

    [Header("Bullet Stats")]
    public GameObject bullet;
    public float bulletLife;
    public float bulletSpeed;
    public float bulletDelay;
    public int bulletCount;
    public bool bulletStop;
    public float waitTime;
    public GameObject playerTarget;
    public bool isAimed = false;
    public float shotAngle;

    [Header("Spawner Stats")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private float cooldown = 0f;
    


    private void Update()
    {
        timer += Time.deltaTime;
        if (isAimed)
        {
            Vector3 Look = transform.InverseTransformPoint(playerTarget.transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - shotAngle;
            transform.Rotate(0, 0, Angle);
        }
        
        if (spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);

        else if (spawnerType == SpawnerType.Antispin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z - 1f);

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0)
        {
            cooldown = waitTime;
            for (int i = 0; i <= bulletCount; i++)
            {
                if (timer >= firingRate)
                {
                    Invoke("Shoot", bulletDelay);
                    timer = 0;
                }
            }
        }
    }

    private void Shoot()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullets>().bulletSpeed = bulletSpeed;
            spawnedBullet.GetComponent<Bullets>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
