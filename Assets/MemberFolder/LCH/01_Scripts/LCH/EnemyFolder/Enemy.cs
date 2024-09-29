using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum EnemyStateEnum
{
   plus,Minus,Multiplication,Division, FourBasicOperations, Hit,Dead
}
public class Enemy : EnemySetting
{
    public StateMachine<EnemyStateEnum> StateMachine { get; set; }

    [field:SerializeField] public EnemyStatsSo _enemystats;

    public UnityEvent EnemyAttackEvent; //Enemy�� �´� ���� �ֱ�

    private void OnEnable()
    {
        HelathCompo.Hp = _enemystats.Hp;
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
