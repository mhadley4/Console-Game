using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Random_Damage : MonoBehaviour
{
    public int EnemyHealth = 10;
    public int DamageMax = 1;
    public int DamageMin = 10;

    public void DamageEnemy()
    {
        EnemyHealth -= Random.Range(DamageMax, DamageMin);
        Debug.Log(EnemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
