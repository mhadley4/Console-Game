using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class encounter : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "mele")
        {
            PlayerPrefs.SetString("enemytype", "melee");
            SceneManager.LoadScene("BattleScene");
        }
        if (coll.gameObject.tag == "ranged")
        {
            PlayerPrefs.SetString("enemytype", "longranged");
            SceneManager.LoadScene("BattleScene");
        }
    }
}
