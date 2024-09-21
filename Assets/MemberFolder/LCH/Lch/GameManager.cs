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
        Debug.Log("���� ����");
    }

    private void HandlAttackEnd()
    {
        state = TrunState.playerTurn;
        Debug.Log("�÷��̾� ��");
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

    public void PlayerAttackButton() //���ݹ�ư Ŭ��
    {
        if(state != TrunState.playerTurn) // �÷��̾� ���� �ƴҶ��� ������ �������� �ʰ� �ϱ�
        {
            return;
        }
        _problemUI.SetActive(true);//���� UI����
    }

    public void PlayerAttackCheck()
    {
        //if (_isFinish) //�̰� true�� �ʹ� �ߵǿ�..
        {
            PlayerAttack(); //�����ѵ� EnemyTrune���� �ѱ�� �޼���
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
        //������ ��� �ڵ� ����

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
