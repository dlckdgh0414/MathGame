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
                Pase1Attack1();
                break;
        }
    }

    private void Pase1Attack1()
    {
        
    }

    private void Pase2()
    {
        
    }
    private void LastPase()
    {
        
    }

}
