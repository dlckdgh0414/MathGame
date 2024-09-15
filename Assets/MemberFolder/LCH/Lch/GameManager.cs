using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum TrunState
    {
        start,playerTurn,enemyTurn, win
    }

    public TrunState state;
    public bool isDead;
    public bool useItem;

    private void Awake()
    {
        state = TrunState.start;
        BattleStart();
    }

    private void BattleStart()
    {
        state = TrunState.playerTurn;
    }

    public void PlayerAttackButton()
    {
        if(state != TrunState.playerTurn)
        {
            return;
        }
        
        PlayerAttack();
    }

     public void PlayerAttack()
    {
        //���� ��ų ������ �� �ڵ� �ۼ�
        if (isDead)
        {
            state = TrunState.win;
            EndBattle();
        }
        else
        {
            state = TrunState.enemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

     IEnumerator EnemyTurn()
     {
        useItem = false;
        yield return new WaitForSeconds(1f);
        //���� �ڵ� ����
     }

    public void PlayerItemButton()
    {
        if (state != TrunState.playerTurn)
        {
            return;
        }

        UsingItem();
    }

    private void UsingItem()
    {
        //������ ��� �ڵ� ����

        if(useItem)
         StartCoroutine(EnemyTurn());
    }

    private void EndBattle()
    {
        Debug.Log("���� ����");
    }

}
