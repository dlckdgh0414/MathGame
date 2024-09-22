using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourBasicOperationsSkil : MonoBehaviour
{
    private Enemy _enmyOwer;
    private void Awake()
    {
        _enmyOwer = GetComponentInParent<Enemy>();
    }
    public void Pases()
    {
        if(_enmyOwer.HelathCompo.Hp > 90)
        {
            Pase1();
        }
        else if(_enmyOwer.HelathCompo.Hp <= 90)
        {
            Pase2();
        } 
        else if(_enmyOwer.HelathCompo.Hp <= 5)
        {
            LastPase();
        }
    }


    private void Pase1()
    {
        int rand = Random.Range(0,4);

        switch (rand)
        {
            case 1:
               StartCoroutine(Pase1Attack1());
                break;
            case 2:
                //StartCoroutine(Pase1Attack2());
                break;
        }
    }

    //private string Pase1Attack2()
    //{
        
    //}

    private IEnumerator Pase1Attack1()
    {
        PoolManager.Instance.Pop("PlusAttackBase");
        yield return new WaitForSeconds(0.5f);
        Ipoolable item = GameObject.Find("PlusAttack2").GetComponent<Ipoolable>();
        PoolManager.Instance.Push(item);

    }

    private void Pase2()
    {
        
    }
    private void LastPase()
    {
        
    }

}
