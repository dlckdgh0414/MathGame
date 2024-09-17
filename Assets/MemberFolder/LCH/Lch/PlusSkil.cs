using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSkil : MonoBehaviour
{
    private int Count;
    public Pooling enemy;

    public void PlusTurn()
    {
        StartCoroutine(EnemyAttackSkill());
    }

    private IEnumerator EnemyAttackSkill()
    {
        while (Count <= 10)
        {
            Count++;

            // PoolManager���� ��ü�� ������ ��ġ�� ����
            enemy = PoolManager.Instance.Pop("PlusAttack") as Pooling;
            if (enemy != null)
            {
                enemy.gameObject.transform.position = transform.position;
            }

            // 0.8�� ��� �� �ٽ� ���� ����
            yield return new WaitForSeconds(0.8f);
        }
        Count = 0;
    }
}
