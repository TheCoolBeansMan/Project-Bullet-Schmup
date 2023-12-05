using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Stats")]
    public GameObject bullet;
    public float bulletLife;
    public float bulletSpeed;
    public float bulletDelay;
    public int bulletCount;
    public bool bulletStop;
    public float waitSeconds;

    [Header("Spawner Stats")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;


    private void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);

        StartCoroutine(InvokeBullets());
    }

    IEnumerator InvokeBullets()
    {
        WaitForSeconds secondDelay = new WaitForSeconds(waitSeconds);

        if (timer >= firingRate)
        {
            for (int i = 0; i <= bulletCount; i++)
            {
                Invoke("Shoot", bulletDelay);
                timer = 0;
            }
            yield return secondDelay;
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
