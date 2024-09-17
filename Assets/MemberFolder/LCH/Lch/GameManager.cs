using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public enum TrunState
    {
        start,playerTurn,enemyTurn, win
    }

    public TrunState state;
    public bool isDead;
    public bool useItem;

    public UnityEvent OnEnemyAttackStart;
    public event Action OnEnemyAttackEnd;
    public event Action OnBattleEnd;
    public event Action OnItemUse;

    public EnemyStatSOList enemyStatList;

    private List<EnemyStatsSo> _enemyList = new List<EnemyStatsSo>();
    private EnemyStatsSo _currentEnemy;

    private void OnEnable()
    {
        OnEnemyAttackEnd += HandlAttackEnd;
        OnBattleEnd += HandleBattleEnd;
    }

    private void HandleBattleEnd()
    {
        Debug.Log("전투 종료");
    }

    private void HandlAttackEnd()
    {
        state = TrunState.playerTurn;
        Debug.Log("플레이어 턴");
    }

    private void Awake()
    {
        foreach (EnemyStatsSo enemy in enemyStatList.enemyStatList)
        {
            _enemyList.Add(enemy);
        }
        _currentEnemy = _enemyList[0];

        state = TrunState.start;
        StartCoroutine(EnemyAttackRoutine());
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
            OnBattleEnd?.Invoke();
        }
        else
        {
            state = TrunState.enemyTurn;
            OnEnemyAttackStart?.Invoke();
        }
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

        if (useItem)
        {
            OnItemUse?.Invoke();
            OnEnemyAttackStart?.Invoke();
        }
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitForSeconds(_currentEnemy.AttackDuration);
        OnEnemyAttackEnd?.Invoke();
    }
}
