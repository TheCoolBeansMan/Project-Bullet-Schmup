using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Stage2Manager : MonoBehaviour
{
    public GameObject dialogueManagerPreFight;
    public GameObject dialogueManagerPostFight;

    public GameObject enemyE;
    public GameObject enemyF; 
    public GameObject enemyG;

    public GameObject enemyH1;
    public GameObject enemyH2;
    public GameObject enemyH3;
    public GameObject enemyH4;

    public GameObject midboss;
    public GameObject midbossEnemy;

    public GameObject enemyI;
    public GameObject enemyI1;
    public GameObject enemyI2;
    public GameObject enemyI3;
    public GameObject enemyI4;
    public GameObject enemyI5;
    //public GameObject enemyJ;

    public GameObject boss1;
    public GameObject bossEnemy;
    public GameObject boss2;
    public GameObject bossEnemy2;
    public GameObject boss3;
    public GameObject bossEnemy3;
    public GameObject boss4;
    public GameObject bossEnemy4;
    //public GameObject boss5;
    //public GameObject bossEnemy5;

    //public Destructable currentHP;

    private float timer = 0f;
    //private float midbossTimer = 0f;
    public bool timeActive = false;
    private int lastSecondLogged = -1;
    private bool midbossDead = false;

    private GameObject[] bulletsOnScreen;
    public GameObject scoreTracker;


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

        midboss.SetActive(false);

        enemyI.SetActive(false);

        boss1.SetActive(false);
        boss2.SetActive(false);
        boss3.SetActive(false);
        //enemyJ.SetActive(false);
        boss4.SetActive(false);
        //boss5.SetActive(false);


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

        if (timeActive && timer >= 28f)
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

        if (midbossEnemy == null)
        {
            FormationI();
            Debug.Log("Trigger Next Formation");
        }

        if ((enemyI1 == null && enemyI2 == null && enemyI3 == null && enemyI4 == null && enemyI5 == null && bossEnemy != null) || Input.GetKeyDown(KeyCode.V))
        {
            Invoke("Boss", 5f);
        }

        if (bossEnemy == null && bossEnemy2 != null)
        {
            Boss2();
        }

        if ((bossEnemy == null && bossEnemy2 == null && bossEnemy3 != null) || Input.GetKeyDown(KeyCode.B)) //Included a Debug button to force-spawn in the event of spawn failure
        {
            Boss3();
        }

        if ((bossEnemy == null && bossEnemy2 == null && bossEnemy3 == null && bossEnemy4 != null) || Input.GetKeyDown(KeyCode.N)) //Included a Debug button to force-spawn in the event of spawn failure
        {
            Boss4();
        }

        /*if ((bossEnemy == null && bossEnemy2 == null && bossEnemy3 == null && bossEnemy4 == null))
        {
            BulletDestroy();
        }*/

        if (bossEnemy4 == null)
        {
            dialogueManagerPostFight.GetComponent<Dialogue>().dialogueActivated = true;
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

        if (midboss != null)
        {
            timeActive = false;
            midboss.SetActive(true);

            if (GameObject.FindGameObjectsWithTag("midboss") == null)
            {
                timeActive = true;
                midbossDead = true;
                midboss.SetActive(false);
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

    //float bossTimer;
    //Vector2 bossPos;
    void Boss()
    {
        dialogueManagerPreFight.GetComponent<Dialogue>().dialogueActivated = true;
        if (dialogueManagerPreFight == null)
        {
            //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
            boss1.SetActive(true);
            bossEnemy.SetActive(true);
            timeActive = false;
        }
    }

    void Boss2()
    {
        //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
        boss2.SetActive(true);
        bossEnemy2.SetActive(true);
        boss1.SetActive(false);
        timeActive = false;
    }

    //void Boss3old()
    //{
    //    //bossTimer = 0;
    //    if (boss3 != null)
    //    {
    //        //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
    //        boss2.SetActive(false);
    //        boss3.SetActive(true);
    //        bossEnemy3.SetActive(true);
    //        //enemyJ.SetActive(true);
    //        timeActive = false;
    //    }
    //    else
    //        Debug.Log("Debug Warning: boss not assigned.");
    //}

    void Boss3()
    {
        //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
        boss3.SetActive(true);
        bossEnemy3.SetActive(true);
        boss2.SetActive(false);
        timeActive = false;
    }

    void BulletDestroy()
    {
        scoreTracker.GetComponent<MeterManager>().score += 001000;
        bulletsOnScreen = GameObject.FindGameObjectsWithTag("RedBullet");
        for (int i = 0; i < bulletsOnScreen.Length; i++)
        {
            Destroy(bulletsOnScreen[i]);
        }
        bulletsOnScreen = GameObject.FindGameObjectsWithTag("BlueBullet");
        for (int i = 0; i < bulletsOnScreen.Length; i++)
        {
            Destroy(bulletsOnScreen[i]);
        }
        bulletsOnScreen = GameObject.FindGameObjectsWithTag("BlackBullet");
        for (int i = 0; i < bulletsOnScreen.Length; i++)
        {
            Destroy(bulletsOnScreen[i]);
        }
    }

    void Boss4()
    {
        //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
        boss4.SetActive(true);
        bossEnemy4.SetActive(true);
        boss3.SetActive(false);
        timeActive = false;
    }
}
