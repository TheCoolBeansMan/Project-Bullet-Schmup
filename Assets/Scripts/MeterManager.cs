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

    PlayerControl player;

    private void Update()
    {
        if (healthSlider.value == 100)
        {
            healthGraze -= healthDecrease;
            healthSlider.value = 0;
            player.lives++;
            player.playerLives[player.lives].SetActive(true);
        }
        if (bombSlider.value >= 100 && player.bombs <= 6)
        {
            bombGraze -= bombDecrease;
            bombSlider.value = 0;
            player.bombs++;
            player.playerBombs[player.bombs].SetActive(true);
        }
        if (powerSlider.value >= 100 && player.gunTier <= 4)
        {
            powerGraze -= powerDecrease;
            powerSlider.value = 0;
            player.gunTier++;
            player.playerPower[player.gunTier].SetActive(true);
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
