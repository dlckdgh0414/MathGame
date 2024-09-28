using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class Phase1Attack4Skil : MonoBehaviour
{

    public Pooling _pool;

	public void Phase1Attack4()
    {
        StartCoroutine(Attack4());
    }

    private IEnumerator Attack4()
    {
        while (true)
        {
          float rand =  Random.Range(3.37f, -3.26f);

            transform.DOMoveX(rand, 0.5f);
            yield return new WaitForSeconds(0.3f);
           _pool =  PoolManager.Instance.Pop("Minus3") as Pooling;

            if(_pool != null)
            {
                _pool.gameObject.transform.position = transform.position;
            }
        }
    }
}
