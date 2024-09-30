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
    private int _itemCount;

    public GameObject _mainScreen;
    public GameObject _gameScreen;
    public Action OnEnemyAttackStart;
    public event Action OnEnemyAttackEnd;
    public Action OnBattleEnd;
    public event Action OnItemUse;

    public EnemyStatSOList enemyStatList;
    private List<EnemyStatsSo> _enemyList = new List<EnemyStatsSo>();
    public List<GameObject> _itemList = new List<GameObject>();
    private EnemyStatsSo _currentEnemy;
    [SerializeField] private GameObject _problemUI;
    private Health _player;
    private Enemy _enemy;
    public bool _isFinish;
    public bool _EnemyTrunEnd = false;
    private bool _isOpen;
    private bool _isEndGame;
    private static int _enemyCount = 0;
    [SerializeField] private GameObject _itemBag;

    [SerializeField] Enemy[] _enemyPrefab;

    public int cut = 0;

    private void OnEnable()
    {
        OnEnemyAttackStart += HandleAttackStart;
        OnEnemyAttackEnd += HandlAttackEnd;
        OnBattleEnd += HandleBattleEnd;
    }

    private void HandleBattleEnd()
    {
        state = TrunState.win;
        _itemList[_randomInt].SetActive(true);
        _randomInt = UnityEngine.Random.Range(0, _itemCount);
        _isFinish = false;
        isDead = false;
        _mainScreen.SetActive(true);
        _gameScreen.SetActive(false);
        GameObject.FindWithTag("Enemy").SetActive(false);
        GameObject.Find("Player").SetActive(false);
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
            case EnemyStateEnum.Minus:
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
        foreach (EnemyStatsSo enemy in enemyStatList.enemyStatList)
        {
            _enemyList.Add(enemy);
        }

        _currentEnemy = _enemyList[_enemyCount];

        state = TrunState.start;

        _itemCount = _itemBag.transform.childCount;
        _randomInt = UnityEngine.Random.Range(0, _itemCount);

    }

    private void Start()
    {
        _isOpen = false;
        state = TrunState.playerTurn;

        print(_randomInt);

        Debug.Log(_enemyPrefab[cut]);

        for (int i = 0; i < _itemCount; i++)
        {
            _itemList.Add(_itemBag.transform.GetChild(i).gameObject);
            _itemList[i].SetActive(false);
        }
        _itemBag.SetActive(false);
        _problemUI.SetActive(false);
    }


    public void BattleStart()
    {
        Instantiate(_enemyPrefab[cut], new Vector3(-0.02f, 3.21f, 0), Quaternion.identity);

        state = TrunState.playerTurn;
        _player = GameObject.Find("Player").GetComponent<Health>();
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
    }

    private void EnemyDie()
    {
        isDead = _enemy.HelathCompo.Hp <= 0;
        Debug.Log($"Dead : {isDead} Cut : {cut}");
    }

    public void PlayerAttackButton() 
    {
        if (state != TrunState.playerTurn)
        {
            _problemUI.SetActive(false);
            return;
        }
        else
        {
            _problemUI.SetActive(true);
        }
    }

    public void PlayerAttackCheck()
    {
        if (_isFinish)
        {
            PlayerAttack();
        }
    }

    public void PlayerAttack()
    {
        _isFinish = false;
        OnEnemyAttackStart?.Invoke();
    }

    public void PlayerItemButton()
    {
        if (state != TrunState.playerTurn)
        {
            _itemBag.SetActive(false);
            return;
        }

        UsingItem();
    }

    public void PlayerDie()
    {
    }

    private void GetItem()
    {

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

    private void Update()
    {
        PlayerDie();
        PlayerAttackCheck();
    }
}
