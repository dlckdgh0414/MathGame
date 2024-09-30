using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum EnemyStateEnum
{
   plus,Minus,Multiplication,Division, FourBasicOperations, Hit,Dead
}
public class Enemy : EnemySetting
{
    [SerializeField] private Image _enemyHp;
    public StateMachine<EnemyStateEnum> StateMachine { get; set; }

    [field:SerializeField] public EnemyStatsSo _enemystats;

    public UnityEvent EnemyAttackEvent; //Enemy에 맞는 공격 넣기

    private void Start()
    {
        HelathCompo.Hp = _enemystats.Hp;
    }

    private void Update()
    {
        _enemyHp.fillAmount = HelathCompo.Hp / _enemystats.Hp;
        if (HelathCompo.Hp <= 0)
        {
            GameManager.Instance.isDead = true;
            GameManager.Instance.OnBattleEnd?.Invoke();
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
