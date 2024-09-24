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

    private Transform _playerTrm;
    private Pooling[] _division = new Pooling[2];
    private bool isChase = false;

    [SerializeField] private float _duration = 5f;
    private float _currentTime;

    private void Awake()
    {
        for(int i = 0; i < _pushZone.Length; i++)
        {
            _pushZone[i] = GameObject.Find($"PrefabPush{i + 1}").transform;
        }

        _playerTrm = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (isChase)
            ChasePlayer();
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
            for(int i = 0; i < 2; i++)
            {
                enemy = PoolManager.Instance.Pop("Division") as Pooling;

                if (enemy != null)
                {
                    _division[i] = enemy;
                }

                _division[i].transform.position = _pushZone[i].transform.position;
            }

            _division[1].transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        StartCoroutine(DivisionPhase2Attack());
        isChase = true;
    }

    private void ChasePlayer()
    {
        if (_currentTime < _duration)
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    _division[i].transform.DOMove(new Vector2(_playerTrm.position.x, _pushZone[i].position.y), 1f);
                else
                    _division[i].transform.DOMove(new Vector2(_pushZone[i].position.x, _playerTrm.position.y), 1f);
            }
            _currentTime += Time.deltaTime;
        }

        if (_currentTime > _duration) isChase = false;
            _currentTime = 0;
    }

    private IEnumerator DivisionPhase2Attack()
    {
        while (isChase)
        {
            for (int i = 0; i < 2; i++)
            {
                yield return new WaitForSeconds(1f);

                lazer.ShotExpolmeArr(
                    new[] { _division[i].transform },
                    new[] { _pushZone[i].rotation },
                    _division[i].transform);

                yield return new WaitForSeconds(0.6f);

                lazer.ShootLazerArr(
                    new[] { _division[i].transform },
                    new[] { _pushZone[i].rotation },
                    _division[i].transform);
            }
        }
    }

    private IEnumerator LazerShootingRoutine(int rand)
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
    }
}
