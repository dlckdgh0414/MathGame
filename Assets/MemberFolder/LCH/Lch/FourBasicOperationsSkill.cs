using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourBasicOperationsSkill : MonoBehaviour
{

    private Enemy _enmyOwer;
    [SerializeField] Transform[] _boasPos;
    [SerializeField] Transform _lastPos;
    public Pooling enemy;
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
        //int rand = Random.Range(0, 4);

        //switch (rand)
        //{
        //    case 1:
        //        StartCoroutine(Pase1Attack1());
        //        break;
        //    case 2:
        //        StartCoroutine(Pase1Attack2());
        //        break;
        //    case 3:
                StartCoroutine(Pase1Attack3());
        //        break;
        //}
    }

    private IEnumerator Pase1Attack3()
    {
        for(int i = 0; i < 2; i++)
        {
            
             enemy =  PoolManager.Instance.Pop("Minus2") as Pooling;
            if (enemy != null)
            {
                enemy.gameObject.transform.position = _boasPos[i].position;
            }

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
        yield return new WaitForSeconds(2f);
        Ipoolable item = GameObject.Find("PlusAttack2").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);

        GameManager.Instance._EnemyTrunEnd = false;

    }

    private void Pase2()
    {

    }
    private void LastPase()
    {

    }

}
