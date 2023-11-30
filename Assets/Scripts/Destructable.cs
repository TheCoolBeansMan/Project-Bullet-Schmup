using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public string target;
    public float maxHitpoints;
    public float hitpoints;

    private void Start()
    {
        hitpoints = maxHitpoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
            }
        }
    }
}
