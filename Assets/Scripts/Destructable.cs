using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public string target;
    public float maxHitpoints;
    public float hitpoints;
    public int bossLives;
    public GameObject[] attackPattern;
    public int bossPhase;
    public bool bossActive;
    public GameObject scoreTracker;

    private void Start()
    {
        hitpoints = maxHitpoints;
        //attackPattern[0].SetActive(true);
    }
    private void Update()
    {
        if(bossActive)
        {
            Invoke("BossAttack", 1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Bullets bullet = collision.GetComponent<Bullets>();
        float damage = bullet.GetComponent<Bullets>().bulletDamage;

        if (bullet != null && collision.tag == target)
        {
            hitpoints -= damage;
            Destroy(bullet.gameObject);

            if (this.gameObject.CompareTag("boss") || this.gameObject.CompareTag("midboss"))
            {
                BossHealth();
            }

            else if (this.gameObject.CompareTag("Enemy") && hitpoints <= 0)
            {
                scoreTracker.GetComponent<MeterManager>().score += 000100;
                Destroy(gameObject);
            }


        }
    }

    public void BossHealth()
    {

        if (hitpoints <= 0)
        {
            hitpoints = maxHitpoints;
            bossLives--;
            bossPhase++;
            scoreTracker.GetComponent<MeterManager>().score += 002500;
        }

        if (bossLives <= 0)
        {
            Destroy(gameObject);
            bossActive = false;
            scoreTracker.GetComponent<MeterManager>().score += 005000;
        }
    }

    //public void BossAttack()
    //{
    //    for (bossPhase = 0; bossPhase <= attackPattern.Length; bossPhase++)
    //    {
    //        attackPattern[bossPhase].SetActive(true);
    //        attackPattern[bossPhase - 1].SetActive(false);
    //    }
    //}

}
