using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FourBasicOperationsSkill : MonoBehaviour
{

    private Enemy _enmyOwer;
    [SerializeField] Transform[] _boasPos;
    [SerializeField] Transform _lastPos;
    public Pooling enemy;
    public UnityEvent Phase1Attack4Event;
    public UnityEvent DivisonAttackEvent;
    public UnityEvent LastPhaseEvent;
    public UnityEvent DivisonAttackEvent2;
    private PlusMove2 _plusMove;
    public Pooling enemy2;
    public Pooling enemy3;
    public Pooling enemy4;

    private void Awake()
    {
        _enmyOwer = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        Phase1Attack4Event?.Invoke();
        DivisonAttackEvent?.Invoke();
    }

    public void Pases()
    {
        if (_enmyOwer.HelathCompo.Hp > 90)
        {
            Pase1();
        }
        else if (_enmyOwer.HelathCompo.Hp <= 90&&_enmyOwer.HelathCompo.Hp > 5)
        {
            Pase2();
        }
        if (_enmyOwer.HelathCompo.Hp <= 5)
        {
            LastPhaseAttack();
        }
    }

    private void LastPhaseAttack()
    {
        Debug.Log("마지막패턴");
        LastPhaseEvent?.Invoke();
    }

    private void Pase1()
    {
        int rand = Random.Range(1, 5);

        switch (rand)
        {
            case 1:
                StartCoroutine(Pase1Attack1());
                break;
            case 2:
                StartCoroutine(Pase1Attack2());
                break;
            case 3:
                StartCoroutine(Pase1Attack3());
                break;
            case 4:
                Phase1Attack4Event?.Invoke();
                break;
        }
    }
    private IEnumerator Pase1Attack3()
    {      
             enemy =  PoolManager.Instance.Pop("Minus2") as Pooling;
            enemy2 = PoolManager.Instance.Pop("Minus3") as Pooling;
             
            if (enemy != null)
            {
                enemy.gameObject.transform.position = _boasPos[1].position;
            }
            if(enemy2 != null)
            {
                enemy2.gameObject.transform.position = _boasPos[0].position;
            }
        yield return new WaitForSeconds(0.1F);
    }

    private IEnumerator Pase1Attack2()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            enemy = PoolManager.Instance.Pop("PlusAttack3") as Pooling;
            if (enemy != null)
            {
                enemy.gameObject.transform.position = transform.position;
                {
                }
            }
        }
            yield return new WaitForSeconds(3.5f);
            GameManager.Instance._EnemyTrunEnd = true;
    }

    private IEnumerator Pase1Attack1()
    {
       enemy = PoolManager.Instance.Pop("PlusAttackBase") as Pooling;
        if(enemy != null)
        {
            enemy.gameObject.transform.position = transform.position;
        }
        DivisonAttackEvent?.Invoke();
        yield return new WaitForSeconds(2f);
        Ipoolable item = GameObject.FindWithTag("EnemyPrefab").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);
        yield return new WaitForSeconds(5f);

        GameManager.Instance._EnemyTrunEnd = true;
    }

    private void Pase2()
    {
        //int rand = Random.Range(1, 5);
        //switch (rand)
        //{
        //    case 1:
        //        StartCoroutine(Phase2Attack());
        //        break;
        //    case 2:
        //        StartCoroutine(Phase2Attack2());
        //        break;
        //    case 3:
        //        StartCoroutine(Phase2Attack3());
        //        break;
        //    case 4:
        Phase1Attack4Event?.Invoke();
        for (int i = 0; i < 5; i++)
                {
                    DivisonAttackEvent2?.Invoke();
                }
        //        break;
        //}
    }

    private IEnumerator Phase2Attack3()
    {
        for (int i = 4; i < 6; i++)
        {
            enemy3 = PoolManager.Instance.Pop("Minus4") as Pooling;

            if (enemy3 != null)
            {
                enemy3.gameObject.transform.position = _boasPos[i].position;
            }

        }

        for (int i = 2; i < 4; i++)
        {

            enemy4 = PoolManager.Instance.Pop("Minus5") as Pooling;

            if(enemy4 != null)
            {
                enemy4.gameObject.transform.position = _boasPos[i].position;
            }
        }

        yield return new WaitForSeconds(3F);
        GameManager.Instance._EnemyTrunEnd = true;
    }

    private IEnumerator Phase2Attack2()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(1f);
            PoolManager.Instance.Pop("PlusAttack3");
        }
        yield return new WaitForSeconds(6f);
        GameManager.Instance._EnemyTrunEnd = true;
    }

    private IEnumerator Phase2Attack()
    {
        enemy = PoolManager.Instance.Pop("PlusAttackBase") as Pooling;
        if (enemy != null)
        {
            enemy.gameObject.transform.position = transform.position;
        }
        DivisonAttackEvent?.Invoke();
        _plusMove = GameObject.FindWithTag("EnemyPrefab").GetComponent<PlusMove2>();
        _plusMove._moveSpeed = 8f;
        yield return new WaitForSeconds(2f);
        Ipoolable item = GameObject.FindWithTag("EnemyPrefab").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);
        yield return new WaitForSeconds(5f);
        GameManager.Instance._EnemyTrunEnd = true;
    }
}
