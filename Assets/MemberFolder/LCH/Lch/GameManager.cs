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
        //공격 스킬 데미지 등 코드 작성
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
        //공격 코드 적기
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
        //아이템 사용 코드 적기

        if(useItem)
         StartCoroutine(EnemyTurn());
    }

    private void EndBattle()
    {
        Debug.Log("전투 종료");
    }

}
