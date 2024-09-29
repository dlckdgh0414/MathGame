using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisonAttackEvent : MonoBehaviour
{
    private int Count;

    private Transform[] _pushZone = new Transform[3];

    public Pooling enemy;
    public Lazer lazer;
    public EnemyStatsSo enemyStat;

    private Transform _playerTrm;
    private Pooling[] _division;
    private bool isChase = false;

    public void DivisionPhase1()
    {
        for(int i = 0; i < 5; i++)
        {
            enemy = PoolManager.Instance.Pop("Division") as Pooling;

            if (enemy != null)
            {
                int rand = Random.Range(0, _pushZone.Length);

                float offsetX = Random.Range(-(_pushZone[rand].localScale.x / 2) + 2,
                    (_pushZone[rand].localScale.x / 2) - 2);

                enemy.transform.rotation = _pushZone[rand].transform.rotation;

                Vector3 offset = new Vector3(offsetX,
                    _pushZone[rand].localScale.y - 0.5f);

                if (enemy.transform.rotation.z != 0)
                    offset = new Vector3(_pushZone[rand]
                        .localScale.y - 0.5f, offsetX);

                enemy.transform.position = _pushZone[rand].localPosition + offset;
                Count++;

                StartCoroutine(LazerShootingRoutine(rand, enemy));
            }
        }
    }

    private IEnumerator LazerShootingRoutine(int rand, Pooling enemy)
    {
        lazer.ShotExpolmeArr(
            new[] { enemy.transform },
            new[] { _pushZone[rand].rotation },
            enemy.transform);

        yield return new WaitForSeconds(0.6f);

        lazer.ShootLazerArr(
            new[] { enemy.transform },
            new[] { _pushZone[rand].rotation },
            enemy.transform);

        yield return new WaitForSeconds(2f);

        PoolManager.Instance.Push(enemy);
    }
}
