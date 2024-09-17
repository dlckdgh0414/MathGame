using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyStateEnum
{
   plus,Minusus,Multiplication,Division, Hit,Dead
}
public class Enemy : EnemySetting
{
    public StateMachine<EnemyStateEnum> StateMachine { get; set; }

    [SerializeField] private EnemyStatsSo _enemystats;

    public UnityEvent EnemyAttackEvent; //Enemy에 맞는 공격 넣기

    private void Start()
    {
        HelathCompo.Hp = _enemystats.Hp;
    }

    public void HandleAttackStart()
    {
        switch (_enemystats.EnemyName) 
        {
            case EnemyStateEnum.plus:
                Debug.Log("Enemy State: plus");
                EnemyAttackEvent?.Invoke();
                break;
            case EnemyStateEnum.Minusus:
                Debug.Log("Enemy State: Minusus");
                EnemyAttackEvent?.Invoke();
                break;
            case EnemyStateEnum.Multiplication:
                Debug.Log("Enemy State: Multiplication");
                EnemyAttackEvent?.Invoke();
                break;
            case EnemyStateEnum.Division:
                Debug.Log("Enemy State: Division");
                EnemyAttackEvent?.Invoke();
                break;
            default:
                Debug.LogWarning("Unknown Enemy State");
                break;
        }
    }

    public void GetHit()
    {
        StateMachine.ChangeState(EnemyStateEnum.Hit);
    }

    public override void SetDeadState()
    {
       StateMachine.ChangeState(EnemyStateEnum.Dead);
    }
    public override void AnimationEndTrigger()
    {
        StateMachine.CurrentState.AnimationEndTrigger();
    }
}
