using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void DivisionPhase1()
    {
        if (Count <= 10)
        {
            enemy = PoolManager.Instance.Pop("Division") as Pooling;

            if (enemy != null)
            {
                int rand = Random.Range(0, _pushZone.Length);

                float offsetX = Random.Range(-(_pushZone[rand].localScale.x / 2) + 1, 
                    (_pushZone[rand].localScale.x / 2) - 1);

                enemy.transform.rotation = _pushZone[rand].transform.rotation;

                Vector3 offset = new Vector3(offsetX, _pushZone[rand].localScale.y - 0.5f);

                enemy.transform.position = _pushZone[rand].localPosition + offset;
                Count++;

                StartCoroutine(LazerShootingRoutine(rand));
            }
        }
    }

    private IEnumerator LazerShootingRoutine(int rand)
    {
        //enemy.transform.DOLocalMoveY(_pushZone[rand].localScale.y + 0.5f, 0.25f);

        yield return new WaitForSeconds(1f);
        lazer.ShootLazer(enemy.gameObject.transform.position, _pushZone[rand].localRotation);
    }
}
