using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MultiplySkill : MonoBehaviour
{
	[SerializeField] private float minY, maxY;
	[SerializeField] private float minX, maxX;

    [SerializeField] private int Count = 0;

    public Pooling enemy;
    public void Pase1()
    {
        if(Count <= 2)
        {
            float rangY = Random.Range(minY, maxY);
            float rangX = Random.Range(minX, maxX);

            enemy = PoolManager.Instance.Pop("MultiplicationAttack") as Pooling;
            if (enemy != null)
            {
                enemy.gameObject.transform.position = new Vector2(rangX,rangY);
            }
            Count++;
        }
    }
}
