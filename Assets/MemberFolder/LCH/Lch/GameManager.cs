using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum TrunState
    {
        start, playerTurn, enemyTurn, win
    }

    public TrunState state;
    public bool isDead;
    public bool useItem;
    private int _randomInt;

    public Action OnEnemyAttackStart;
    public event Action OnEnemyAttackEnd;
    public event Action OnBattleEnd;
    public event Action OnItemUse;

    public EnemyStatSOList enemyStatList;

    private List<EnemyStatsSo> _enemyList = new List<EnemyStatsSo>();
    public List<GameObject> _itemList = new List<GameObject>();
    private EnemyStatsSo _currentEnemy;
    private GameObject _problemUI;
    private Enemy _enemy;
    public bool _isFinish;
    public bool _EnemyTrunEnd = false;
    private bool _isOpen;
    private GameObject _itemBag;

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
        _EnemyTrunEnd = false;
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
            case EnemyStateEnum.FourBasicOperations:
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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _randomInt = UnityEngine.Random.Range(0, 9);
        _itemBag = GameObject.Find("ItemBag");
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
        _isOpen = false;
        _itemBag.SetActive(false);
        _problemUI.SetActive(false);
    }

    private void BattleStart()
    {
        state = TrunState.playerTurn;
    }

    public void PlayerAttackButton() //공격버튼 클릭
    {
        if (state != TrunState.playerTurn) // 플레이어 턴이 아닐때는 눌려도 반응하지 않게 하기
        {
            return;
        }
        else
        {
            _problemUI.SetActive(true);
        }
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
            _itemList[_randomInt].SetActive(true);
            _randomInt = UnityEngine.Random.Range(0, 9);
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
        if (_isOpen == false)
        {
            _itemBag.SetActive(true);
            _isOpen = true;
        }
        else if (_isOpen == true)
        {
            _itemBag.SetActive(false);
            _isOpen = false;
        }

        if (useItem)
        {
            OnItemUse?.Invoke();
            OnEnemyAttackStart?.Invoke();
        }
    }

    private IEnumerator EnemyAttackRoutine()
    {
        yield return new WaitUntil(() => _EnemyTrunEnd);
        OnEnemyAttackEnd?.Invoke();
    }

    //private void Update()
    //{
    //    if ()
    //    PlayerAttackCheck();
    //}
}
