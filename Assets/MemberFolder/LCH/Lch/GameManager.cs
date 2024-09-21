using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    public  bool _isFinish;
    private bool _isEnemyTurn;

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
        Debug.Log(_enemy._enemystats.EnemyName);
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
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

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

    private void Start()
    {
        _problemUI.SetActive(false);
    }

    private void BattleStart()
    {
        state = TrunState.playerTurn;
    }

    public void PlayerAttackButton() //공격버튼 클릭
    {
        if(state != TrunState.playerTurn) // 플레이어 턴이 아닐때는 눌려도 반응하지 않게 하기
        {
            return;
        }
        _problemUI.SetActive(true);//문제 UI띄우기
    }

    public void PlayerAttackCheck()
    {
        //if (_isFinish) //이거 true가 너무 잘되요..
        {
            PlayerAttack(); //공격한뒤 EnemyTrune으로 넘기는 메서드
        }
    }

    public void PlayerAttack()
    {
        if (isDead)
        {
            state = TrunState.win;
            OnBattleEnd?.Invoke();
        }
        else
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

    //private void Update()
    //{
    //    if ()
    //    PlayerAttackCheck();
    //}
}
