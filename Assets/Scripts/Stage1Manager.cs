using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    public GameObject enemyA1;
    public GameObject enemyA2; 

    public GameObject enemyB1;
    public GameObject enemyB2;
    public GameObject enemyC1;
    public GameObject enemyC2; 
    public GameObject enemyC3;

    public GameObject midboss;

    public GameObject enemyD;

    public GameObject boss;



    private float timer = 0f;
    private int lastSecondLogged = -1; 

    void Start()
    {
        enemyA1.SetActive(false);
        enemyA2.SetActive(false);
        enemyB1.SetActive(false);
        enemyB2.SetActive(false);
        enemyC1.SetActive(false);
        enemyC2.SetActive(false);
        enemyC3.SetActive(false);
        midboss.SetActive(false);
        enemyD.SetActive(false);
        boss.SetActive(false);

        Invoke("FormationA", 2f);
        Invoke("FormationB", 10f);
        Invoke("FormationC", 10f);
        //Invoke("midboss", 30f);
        Invoke("FormationD", 32f);

    }

    void Update()
    {
        timer += Time.deltaTime;

        int currentSecond = Mathf.FloorToInt(timer);
        if (currentSecond != lastSecondLogged)
        {
            lastSecondLogged = currentSecond;
            Debug.Log("Time: " + currentSecond + " seconds");
        } //Debug Timer that counts seconds via Update

        //Put trigger checks for midboss, Formation D, and Boss endings here...
    }

    void FormationA() //[A1, A2]: Black Fairies shmoove across from the top screen and then off to the side in symmetrical but delayed waves
    {
        if (enemyA1 != null || enemyA2 != null)
        {
            enemyA1.SetActive(true);
            enemyA2.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyA1 or A2 not assigned.");
    }

    void FormationB() //[B1, B2]: Red and Blue Fairies run down the sides of the screen and shoot at the player
    {
        if (enemyB1 != null || enemyB2 != null)
        {
            enemyB1.SetActive(true);
            enemyB2.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyB1 or B2 not assigned.");
    }

    void FormationC()//[C1, C2]: A formation of BLack Birds will spiral around then exit the screen. This is followed by a formation of blue and red birds.
                     //They goes at the same time as Formation B.
    {
        if (enemyC1 != null || enemyC2 != null || enemyC3 != null)
        {
            enemyC1.SetActive(true);
            enemyC2.SetActive(true);
            enemyC3.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyC1, C2, or C3 not assigned.");
    }

    void Midboss()
    {
        if (midboss != null)
        {
            midboss.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: midboss not assigned.");
    }

    void FormationD()
    {
        if (enemyD != null)
        {
            enemyD.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: enemyD not assigned.");
    }

    void Boss()
    {
        if (boss != null)
        {
            //code needs to be modified for boss patterns to engage AFTER dialogue is finished.
            boss.SetActive(true);
        }
        else
            Debug.Log("Debug Warning: boss not assigned.");
    }
}
