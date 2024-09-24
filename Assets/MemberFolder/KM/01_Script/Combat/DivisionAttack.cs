using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DivisionAttack : MonoBehaviour
{
    private int Count;
    private Transform[] _pushZone = new Transform[3];

    public Pooling enemy;
    public Lazer lazer;
    public EnemyStatsSo enemyStat;

    private void Awake()
    {
        for(int i = 0; i < _pushZone.Length; i++)
        {
            _pushZone[i] = GameObject.Find($"PrefabPush{i + 1}").transform;
        }

        StartCoroutine(TestRoutine());
    }

    public void DivisionPhase1()
    {
        if (Count <= 10)
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

                StartCoroutine(LazerShootingRoutine(rand));
            }
        }
    }

    public void DivisionPhase2()
    {
        if (Count <= 10)
        {
            enemy = PoolManager.Instance.Pop("Division") as Pooling;

            if (enemy != null)
            {

            }
        }
    }

    private IEnumerator LazerShootingRoutine(int rand)
    {
        //enemy.transform.DOLocalMoveY(_pushZone[rand].localScale.y + 0.5f, 0.25f);

        lazer.ShotExpolmeArr(new[] { enemy.gameObject.transform }, new[] { _pushZone[rand].rotation });
        yield return new WaitForSeconds(0.6f);

        lazer.ShootLazerArr(new[] { enemy.gameObject.transform }, new[] { _pushZone[rand].rotation });
    }

    private IEnumerator TestRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            DivisionPhase1();
            yield return new WaitForSeconds(1f);
        }
    }
}
