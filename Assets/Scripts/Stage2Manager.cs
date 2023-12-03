using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stage2Manager : MonoBehaviour
{
    public GameObject enemyE;
    public GameObject enemyF; 
    public GameObject enemyG;

    public GameObject enemyH1;
    public GameObject enemyH2;
    public GameObject enemyH3;
    public GameObject enemyH4;

    public GameObject midboss2;
    public GameObject midbossEnemy2;

    public GameObject enemyI;
    public GameObject enemyI1;
    public GameObject enemyI2;
    public GameObject enemyI3;
    public GameObject enemyI4;
    public GameObject enemyI5;

    public GameObject boss2;
    public GameObject bossEnemy2;

    public Destructable currentHP;

    private float timer = 0f;
    //private float midbossTimer = 0f;
    public bool timeActive = false;
    private int lastSecondLogged = -1;
    private bool midbossDead = false;


    void Start()
    {
        timeActive= true;

        enemyE.SetActive(false);
        enemyF.SetActive(false);
        enemyG.SetActive(false);

        enemyH1.SetActive(false);
        enemyH2.SetActive(false);
        enemyH3.SetActive(false);
        enemyH4.SetActive(false);

        midboss2.SetActive(false);

        enemyI.SetActive(false);

        boss2.SetActive(false);


    }

    void Update()
    {
        if (timeActive)
        {
            timer += Time.deltaTime;
        }

        if (timeActive && timer >= 5f)
        {
            FormationE();
        }

        if (timeActive && timer >= 11f)
        {
            enemyE.SetActive(false);
        }

        if (timeActive && timer >= 13f)
        {
            FormationF();
        }

        if (timeActive && timer >= 19f)
        {
            enemyF.SetActive(false);
        }

        if (timeActive && timer >= 21f)
        {
            FormationG();
        }

        if (timeActive && timer >= 30f)
        {
            enemyG.SetActive(false);
        }

        if (timeActive && timer >= 31f)
        {
            FormationH();
        }

        if (timeActive && timer >= 33)
        {
            FormationH2();
        }

        if (timeActive && timer >= 38)
        {
            FormationH3();
        }

        if (timeActive && timer >= 46f)
        {
            enemyH1.SetActive(false);
        }

        if (timeActive && timer >= 48f)
        {
            enemyH2.SetActive(false);
        }

        if (timeActive && timer >= 50f)
        {
            enemyH3.SetActive(false);
        }

        if (timeActive && timer >= 53f)
        {
            enemyH4.SetActive(false);
        }

        if (timeActive && timer >= 50f)
        {
            Midboss();
        }

        if (midbossEnemy2 == null)
        {
            FormationI();
            Debug.Log("Trigger Next Formation");
        }

        if (enemyI1 == null && enemyI2 == null && enemyI3 == null && enemyI4 == null && enemyI5 == null)
        {
            Invoke("Boss2", 5f);
        }



        int currentSecond = Mathf.FloorToInt(timer);
        if (currentSecond != lastSecondLogged)
        {
            lastSecondLogged = currentSecond;
            Debug.Log("Time: " + currentSecond + " seconds");
        } //Debug Timer that counts seconds via Update

    }

    void FormationE() // Black books spawn in and fire
    {
        if (enemyE != null)
        {
            enemyE.SetActive(true);

        }
        else
            Debug.Log("Debug Warning: enemyE not assigned.");
    }

    void FormationF() // More books, but flipped
    {
        if (enemyF != null)
        {
            enemyF.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyF not assigned.");
    }

    void FormationG()// A formation of Blue books and a couple red books
    {
        if (enemyG != null)
        {
            enemyG.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyG not assigned.");
    }

    void FormationH()// Black bats serpantine from the sides of the screen
    {
        if (enemyH1 != null || enemyH2 != null)
        {
            enemyH1.SetActive(true);
            enemyH2.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyG not assigned.");
    }

    void FormationH2()// Blue and Red Bats fly down from the top
    {
        if (enemyH3 != null)
        {
            enemyH3.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyG not assigned.");
    }

    void FormationH3()// Mirror of above
    {
        if (enemyH4 != null)
        {
            enemyH4.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyG not assigned.");
    }

    void Midboss() //Vivia appears
    {

        if (midboss2 != null)
        {
            timeActive = false;
            midboss2.SetActive(true);

            if (GameObject.FindGameObjectsWithTag("midboss") == null)
            {
                timeActive = true;
                midbossDead = true;
                midboss2.SetActive(false);
            }
        }
        else
            Debug.Log("Debug Warning: midboss not assigned.");
    }

    void FormationI() //BALLS!!
    {
        if (enemyI != null)
        {
            enemyI.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyD not assigned.");
    }

    void Boss2() //Vivia appears again for proper fight
    {
        if (boss2 != null)
        {
            //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
            boss2.SetActive(true);
            timeActive = false;
        }
        else
            Debug.Log("Debug Warning: boss not assigned.");
    }
}
