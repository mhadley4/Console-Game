using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class normalenemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyAttack;
    public int enemyAmmo;
    public int randDec;
    public string enemyType;
    public void Attack()
    {
        Debug.Log("enemy attacking");
    }
    public void Block()
    {
        Debug.Log("enemy blocking");
    }
    public void Heal()
    {
        Debug.Log("enemy healing");
    }
    public void Decide()
    {
        randDec = Random.Range(0, 2);
        switch (randDec)
        {
            case 0:
                Attack();
                break;
            case 1:
                Block();
                break;
            case 2:
                Heal();
                break;
        }
    }

    void Start()
    {

        enemyType = PlayerPrefs.GetString("enemytype");
        switch (enemyType)
        {
            case "melee":
                enemyHealth = 100;
                enemyAttack = 1;
                enemyAmmo = 0;
                break;
            case "longranged":
                enemyHealth = 100;
                enemyAttack = 2;
                enemyAmmo = 10;
                break;
            case "closeranged":
                enemyHealth = 5;
                enemyAttack = 3;
                enemyAmmo = 3;
                break;
            case "boss":
                enemyHealth = 100;
                enemyAttack = 10;
                enemyAmmo = 100;
                break;
        }
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
