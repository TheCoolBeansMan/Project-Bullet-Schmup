using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletLife;
    public GameObject impactEffect;

    //Trigger On Spawn
    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    //Manages bullet Damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Add Damage Code
        //Add Impact code if creatue is destroyed
        //Check if enemy
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
