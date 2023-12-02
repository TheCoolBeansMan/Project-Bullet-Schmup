using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public string target;
    public float maxHitpoints;
    public float hitpoints;

    public Stage1Manager stage1;

    private void Start()
    {
        hitpoints = maxHitpoints;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Bullets bullet = collision.GetComponent<Bullets>();
        float damage = bullet.GetComponent<Bullets>().bulletDamage;

        if (bullet != null && collision.tag == target)
        {
            hitpoints -= damage;
            Destroy(bullet.gameObject);

            if (hitpoints <= 0)
            {
                Destroy(gameObject);
                CheckBoss();
            }


        }
    }

    void CheckBoss()
    {
        stage1 = GetComponent<Stage1Manager>();
        GameObject midbossParent = GameObject.Find("MIDBOSS");
        if (GameObject.FindGameObjectWithTag("midboss") != midbossParent)
        {
            midbossParent.SetActive(false);
        }
    }
}
