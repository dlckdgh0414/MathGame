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

    private Enemy _enmyOwer;
    private int _popCount = 2;

    private void Awake()
    {
        _enmyOwer = GetComponentInParent<Enemy>();
    }

    public void Pase1()
    {
       while(Count < _popCount)
        {
            float rangY = Random.Range(minY, maxY);
            float rangX = Random.Range(minX, maxX);

            enemy = PoolManager.Instance.Pop("MultiplicationAttack") as Pooling;
            if (enemy != null)
            {
                enemy.gameObject.transform.position = new Vector2(rangX,rangY);
            }

            if(_enmyOwer.HelathCompo.Hp <= 13)
            {
                _popCount += 1;
            }

            Count++;
        }

        Count = 0;
    }
}
