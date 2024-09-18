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

    public event Action OnEnemyAttackStart;
    public event Action OnEnemyAttackEnd;
    public event Action OnBattleEnd;
    public event Action OnItemUse;

    public EnemyStatSOList enemyStatList;

    private List<EnemyStatsSo> _enemyList = new List<EnemyStatsSo>();
    private EnemyStatsSo _currentEnemy;
    private GameObject _problemUI;
    private Enemy _enemy;
    public static bool _isFinish;

    private void OnEnable()
    {
        OnEnemyAttackStart += HandleAttackStart;
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

    public void HandleAttackStart()
    {
        switch (_enemy._enemystats.EnemyName)
        {
            case EnemyStateEnum.plus:
                Debug.Log("Enemy State: plus");
                EnemyTrun();
                break;
            case EnemyStateEnum.Minusus:
                Debug.Log("Enemy State: Minusus");
                EnemyTrun();
                break;
            case EnemyStateEnum.Multiplication:
                Debug.Log("Enemy State: Multiplication");
                EnemyTrun();
                break;
            case EnemyStateEnum.Division:
                Debug.Log("Enemy State: Division");
                EnemyTrun();
                break;
            default:
                Debug.LogWarning("Unknown Enemy State");
                break;
        }
    }

    private void EnemyTrun()
    {
        state = TrunState.enemyTurn;
        _enemy.EnemyAttackEvent?.Invoke();
        StartCoroutine(EnemyAttackRoutine());
    }

    private void Awake()
    {
        _problemUI = GameObject.Find("MathProblem0");
        foreach (EnemyStatsSo enemy in enemyStatList.enemyStatList)
        {
            _enemyList.Add(enemy);
        }
        _currentEnemy = _enemyList[0];

        state = TrunState.start;
        BattleStart();
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
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
        _problemUI.SetActive(true);

        _isFinish = false;
        //공격 스킬 데미지 등 코드 작성
        if (isDead)
        {
            state = TrunState.win;
            OnBattleEnd?.Invoke();
        }
        else if(_isFinish == true)
        {
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

     public void UsingItem()
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
