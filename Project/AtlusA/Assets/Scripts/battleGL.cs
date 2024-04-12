using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class battleGL : MonoBehaviour
{
    public int turn;
    public bool attacking;
    private normalenemy e;
    public charactercombat c;
    public SaveGame save;
    public LoadGame load;
    public Button AttackButton, GunButton, BombButton, HealButton, InfoButton, FleeButton, AttackButton_Upgr, GunButton_Upgr, HealButton_Upgr, BombButton_Upgr;
    private Object enemyPrefab;
    public string prefabFilename;
    public Image PlayerTurn, EnemyTurn;

    /*
    turn:
    0 = mid turn
    1 = player turn
    2 = enemy turn
     */
    private void Awake()
    {
        prefabFilename = PlayerPrefs.GetString("enemytype");
        enemyPrefab = Resources.Load("Prefabs/" + prefabFilename);
        GameObject enemyprefab = Instantiate(enemyPrefab, new Vector3(27.08f, 1.04f, 165.88f), Quaternion.identity) as GameObject;
        e = enemyprefab.gameObject.GetComponent<normalenemy>();
    }
    void Start()
    {
        turn = 1;
        attacking = false;
        AttackButton.onClick.AddListener(() => StartTurn(AttackButton));
        AttackButton_Upgr.onClick.AddListener(() => StartTurn(AttackButton_Upgr));
        GunButton.onClick.AddListener(() => StartTurn(GunButton));
        GunButton_Upgr.onClick.AddListener(() => StartTurn(GunButton_Upgr));
        BombButton.onClick.AddListener(() => StartTurn(BombButton));
        BombButton_Upgr.onClick.AddListener(() => StartTurn(BombButton_Upgr));
        HealButton.onClick.AddListener(() => StartTurn(HealButton));
        HealButton_Upgr.onClick.AddListener(() => StartTurn(HealButton_Upgr));

//#if UNITY_SWITCH
//        save.InitSave();
//#endif
        //if this doesn't work then just define every enemy prefab at the top and drag all the prefabs into the inspector then decide which one u need.
    }

    public void StartTurn(Button button)
    {
        if (!attacking)
        {
            if (button.name.Equals("Attack"))
            {
                Debug.Log("attacking");
                c.BasicAttack();
            }

            else if (button.name.Equals("Gun"))
            {
                Debug.Log("shooting");
                c.RangedAttack();
            }
            else if (button.name.Equals("Bomb"))
            {
                Debug.Log("throwing bomb");
                c.AOEAttack();
            }
            else if (button.name.Equals("Heal"))
            {
                Debug.Log("healing");
                c.Heal();
            }
            else if (button.name.Equals("Attack_Upgr"))
            {
                Debug.Log("attacking");
                c.HeavyAttack();
            }

            else if (button.name.Equals("Gun_Upgr"))
            {
                Debug.Log("shooting");
                c.HeavyRangedAttack();
            }
            else if (button.name.Equals("Bomb_Upgr"))
            {
                Debug.Log("throwing bomb");
                c.HeavyAOEAttack();
            }
            if (button.name.Equals("Heal_Upgr"))
            {
                Debug.Log("healing");
                c.HeavyHeal();
            }
            attacking = true;
            StartCoroutine(WaitForTurn());
        }
    }

    public IEnumerator WaitForTurn()
    {
        yield return new WaitForSeconds(2);
        e.Decide();
        attacking = false;
    }

    public void Update()
    {
        PlayerTurn.gameObject.SetActive(!attacking);
        EnemyTurn.gameObject.SetActive(attacking);
    }
}
