using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class charactercombat : MonoBehaviour
{
    public int playerHealth;
    public int playerAttack;
    public int playerAmmo;
    public Image WinMessage;
    public Image ResultMessage;
    public Image BackgroundFade;
    public Slider HealthSlider, BulletSlider;

    public normalenemy e;

    //these functions could have enemy health as a parameter and change it depending on player attack
    //or they could just return a number that the battleGL applies to the enemy health

    public void BasicAttack()
    {

        e.enemyHealth -= 10;
    }
    public void HeavyAttack()
    {

        e.enemyHealth -= 20;
    }
    public void Heal()
    {

        playerHealth += 20;

        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }

    }
    public void HeavyHeal()
    {

        playerHealth += 30;

        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }
    }
    public void RangedAttack()
    {

        playerAmmo -= 1;
        e.enemyHealth -= 10;
    }
    public void HeavyRangedAttack()
    {

        playerAmmo -= 1;
        e.enemyHealth -= 20;
    }
    public void AOEAttack()
    {

        if (Random.value < 0.25f)
        {
            e.enemyHealth -= 30;
        }

    }
    public void HeavyAOEAttack()
    {

        if (Random.value < 0.5f)
        {
            e.enemyHealth -= 50;
        }
    }
    public void Block() { }

    void Start()
    {
        playerHealth = PlayerPrefs.GetInt("health");
        playerAttack = PlayerPrefs.GetInt("attack");
        playerAmmo = PlayerPrefs.GetInt("ammo");

        WinMessage.gameObject.SetActive(false);
        ResultMessage.gameObject.SetActive(false);
        BackgroundFade.gameObject.SetActive(false);

        e = FindObjectOfType<normalenemy>();
        if(e == null)
        {
            StartCoroutine(LoadEnemy());
        }
        Debug.Log(e);
    }

    void Win()
    {
        if (e.enemyHealth <= 0)
        {
            WinMessage.gameObject.SetActive(true);
            BackgroundFade.gameObject.SetActive(true);
            ResultMessage.gameObject.SetActive(true);
            StartCoroutine(BattleSceneSwitch());

            //e = FindObjectOfType<normalenemy>();
        }
    }

    public IEnumerator BattleSceneSwitch()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SampleScene");
    }

    public IEnumerator LoadEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        e = FindObjectOfType<normalenemy>();
    }

    public void SetHealth(int playerHealth)
    {
        HealthSlider.value = playerHealth;
    }

    public void SetAmmo(int playerAmmo)
    {
        BulletSlider.value = playerAmmo;
    }

    void Update()
    {
        SetHealth(playerHealth);
        SetAmmo(playerAmmo);
        Win();
    }

    
}

