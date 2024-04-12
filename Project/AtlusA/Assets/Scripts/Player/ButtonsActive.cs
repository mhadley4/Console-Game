using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsActive : MonoBehaviour
{
    public GameObject AttackButton, GunButton, BombButton, HealButton, AttackButton_Upgr, GunButton_Upgr, HealButton_Upgr, BombButton_Upgr;

    // Start is called before the first frame update
    void Start()
    {
        AttackButton_Upgr.SetActive(false);
        GunButton_Upgr.SetActive(false);
        HealButton_Upgr.SetActive(false);
        BombButton_Upgr.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchL();
        SwitchR();
    }

    void SwitchR()
    {
        if (Input.GetButtonDown("SwitchR"))
        {
            AttackButton_Upgr.SetActive(false);
            GunButton_Upgr.SetActive(false);
            HealButton_Upgr.SetActive(false);
            BombButton_Upgr.SetActive(false);
            AttackButton.SetActive(true);
            GunButton.SetActive(true);
            HealButton.SetActive(true);
            BombButton.SetActive(true);
        }

    }

    void SwitchL()
    {
        if (Input.GetButtonDown("SwitchL"))
        {
            AttackButton_Upgr.SetActive(true);
            GunButton_Upgr.SetActive(true);
            HealButton_Upgr.SetActive(true);
            BombButton_Upgr.SetActive(true);
            AttackButton.SetActive(false);
            GunButton.SetActive(false);
            HealButton.SetActive(false);
            BombButton.SetActive(false);
        }
    }
}
