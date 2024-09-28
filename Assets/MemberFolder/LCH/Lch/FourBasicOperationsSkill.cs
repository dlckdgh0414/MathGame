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
    private PlusMove2 _plusMove;
    public Pooling enemy2;
    public Pooling enemy3;
    public Pooling enemy4;

    private void Awake()
    {
        _enmyOwer = GetComponentInParent<Enemy>();
    }
    public void Pases()
    {
        if (_enmyOwer.HelathCompo.Hp > 90)
        {
            Pase1();
        }
        else if (_enmyOwer.HelathCompo.Hp <= 90)
        {
            Pase2();
        }
        else if (_enmyOwer.HelathCompo.Hp <= 5)
        {
            LastPase();
        }
    }


    private void Pase1()
    {
        int rand = Random.Range(0, 5);

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
            PoolManager.Instance.Pop("PlusAttack3");
        }
    }

    private IEnumerator Pase1Attack1()
    {
        PoolManager.Instance.Pop("PlusAttackBase");
        DivisonAttackEvent?.Invoke();
        yield return new WaitForSeconds(2f);
        Ipoolable item = GameObject.FindWithTag("EnemyPrefab").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);

        GameManager.Instance._EnemyTrunEnd = true;

    }

    private IEnumerator Attack4()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            float rand = Random.Range(3.37f, -3.26f);

            transform.DOMoveX(rand, 0.5f);
            enemy = PoolManager.Instance.Pop("Minus3") as Pooling;

            if (enemy != null)
            {
                enemy.transform.position = gameObject.transform.position;
            }
        }
    }


    private void Pase2()
    {
        //int rand = Random.Range(0, 4);
        //switch (rand)
        //{
        //    case 1:
        //        StartCoroutine(Phase2Attack());
        //        break;
        //    case 2:
        //        StartCoroutine(Phase2Attack2());
        //        break;
        //    case 3:
                StartCoroutine(Phase2Attack3());
        //        break;
        //}
    }

    private IEnumerator Phase2Attack3()
    {
            enemy = PoolManager.Instance.Pop("Minus2") as Pooling;

            if (enemy != null)
            {
                enemy.gameObject.transform.position = _boasPos[1].position;
            }
       
            enemy2 = PoolManager.Instance.Pop("Minus3") as Pooling;

        if (enemy2 != null)
        {
            enemy2.gameObject.transform.position = _boasPos[0].position;

        }

        enemy3 = PoolManager.Instance.Pop("Minus4") as Pooling;

        if(enemy3 != null)
        {
            enemy3.gameObject.transform.position = _boasPos[2].position;
        }

        enemy4 = PoolManager.Instance.Pop("Minus5") as Pooling;

        if(enemy4 != null)
        {
            enemy4.gameObject.transform.position = _boasPos[3].position;
        }

        yield return new WaitForSeconds(0.1F);
    }

    private IEnumerator Phase2Attack2()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(1f);
            PoolManager.Instance.Pop("PlusAttack3");
        }
    }

    private IEnumerator Phase2Attack()
    {
        PoolManager.Instance.Pop("PlusAttackBase");
        DivisonAttackEvent?.Invoke();
        _plusMove = GameObject.FindWithTag("EnemyPrefab").GetComponent<PlusMove2>();
        _plusMove._moveSpeed = 8f;
        yield return new WaitForSeconds(2f);
        Ipoolable item = GameObject.FindWithTag("EnemyPrefab").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);

        GameManager.Instance._EnemyTrunEnd = true;
    }

    private void LastPase()
    {

    }

}
