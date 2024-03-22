using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class battleGL : MonoBehaviour
{
    public int turn;
    public bool lastTurn;
    public bool changeturn;
    public normalenemy e;
    public Random_Damage p;

    /*
    lastTurn:
    true = enemy just attacked
    false = player just attacked
     */
    /*
    turn:
    0 = mid turn
    1 = player turn
    2 = enemy turn
     */
    void Start()
    {
        turn = 1;
        changeturn = false;
        lastTurn = true;
    }

    public void StartTurn()
    {
        if(turn == 1)
        {
            p.DamageEnemy();
            Debug.Log("player attack");
            lastTurn = false;
            turn = 2;
        }
        else if(turn == 2)
        {
            e.Attack();
            Debug.Log("enemy attack");
            lastTurn = true;
            turn = 1;
        }
    }

    public IEnumerator WaitForTurn(bool lastTurn)
    {
        yield return new WaitForSeconds(2);
        Debug.Log(turn);
        if (lastTurn)
        {
            turn = 1;
        }
        else if (!lastTurn)
        {
            turn = 2;
        }
    }
}
