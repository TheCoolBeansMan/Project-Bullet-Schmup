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
                CheckMidboss();
                CheckBoss();
            }


        }
    }

    void CheckMidboss()
    {
        GameObject midboss = GameObject.FindGameObjectWithTag("midboss");
        if (midboss != null)
        {
            if (hitpoints <= 0)
            {

            }
        }
    }

    void CheckBoss()
    {
        GameObject midboss = GameObject.FindGameObjectWithTag("boss");
        if (midboss != null)
        {
            if (hitpoints <= 0)
            {

            }
        }
    }
}
