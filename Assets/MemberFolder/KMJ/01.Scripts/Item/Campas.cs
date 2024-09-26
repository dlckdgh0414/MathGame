using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campas : MonoBehaviour
{

    public void LumpyCompass()
    {
        _ = SelectMathButton._damage * 1.41f;
        Debug.Log(SelectMathButton._damage);
        GameManager.Instance.OnEnemyAttackStart.Invoke();
        
    }

    public void ShapeCompass()
    {
        _ = SelectMathButton._damage * 3.14f;

        Debug.Log(SelectMathButton._damage);
        GameManager.Instance.OnEnemyAttackStart.Invoke();
    }    
}
