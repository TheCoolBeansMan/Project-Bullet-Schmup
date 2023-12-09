using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "target")
        {
            player.GetComponent<PlayerControl>().StartCoroutine("GetInvulnerable");
            player.GetComponent<PlayerControl>().Death();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<PlayerControl>().StartCoroutine("GetInvulnerable");
        player.GetComponent<PlayerControl>().Death();
        
    }
}