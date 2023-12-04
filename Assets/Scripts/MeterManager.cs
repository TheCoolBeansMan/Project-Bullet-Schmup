using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterManager : MonoBehaviour
{
    [Header("Graze Meters")]
    public Slider healthSlider;
    public Slider bombSlider;
    public Slider powerSlider;

    [Header("Player Values")]
    public GameObject glow;

    [Header("Meter Values")]
    public int healthGraze;
    public int bombGraze;
    public int powerGraze;
    public int healthDecrease;
    public int bombDecrease;
    public int powerDecrease;

    public GameObject player;

    private void Update()
    {
        if (healthSlider.value >= 100 && player.GetComponent<PlayerControl>().lives <= 5)
        {
            healthGraze -= healthDecrease;
            if (healthGraze <= 0)
                healthGraze = 2;
            healthSlider.value = 0;
            //if (player.GetComponent<PlayerControl>().lives > 5)
                //healthSlider.value = 100;
            player.GetComponent<PlayerControl>().lives++;
            player.GetComponent<PlayerControl>().playerLives[player.GetComponent<PlayerControl>().lives - 1].SetActive(true);
        }
        if (bombSlider.value >= 100 && player.GetComponent<PlayerControl>().bombs <= 5)
        {
            bombGraze -= bombDecrease;
            if (bombGraze <= 0)
                bombGraze = 3;
            bombSlider.value = 0;
            //if (player.GetComponent<PlayerControl>().bombs > 5)
                //bombSlider.value = 100;
            player.GetComponent<PlayerControl>().bombs++;
            player.GetComponent<PlayerControl>().playerBombs[player.GetComponent<PlayerControl>().bombs - 1].SetActive(true);
        }
        if (powerSlider.value >= 100 && player.GetComponent<PlayerControl>().gunTier <= 3)
        {
            powerGraze -= powerDecrease;
            if (powerGraze <= 0)
                powerGraze = 5;
            powerSlider.value = 0;
            //if (player.GetComponent<PlayerControl>().gunTier > 3)
                //powerSlider.value = 100;
            player.GetComponent<PlayerControl>().gunTier++;
            player.GetComponent<PlayerControl>().playerPower[player.GetComponent<PlayerControl>().gunTier - 1].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RedBullet")
        {
            glow.SetActive(true);
            healthSlider.value += healthGraze;
        }
        if (collision.tag == "BlueBullet")
        {
            glow.SetActive(true);
            bombSlider.value += bombGraze;

        }
        if (collision.tag == "BlackBullet")
        {
            glow.SetActive(true);
            powerSlider.value += powerGraze;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        glow.SetActive(false);
    }
}
