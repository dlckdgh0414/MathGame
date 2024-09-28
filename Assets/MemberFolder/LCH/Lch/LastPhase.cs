using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class LastPhase : MonoBehaviour
{
    private Lazer _lazer;
    [SerializeField] private Quaternion[] _rot;
    [SerializeField] private Transform[] _pos;
    [SerializeField] private Transform _lastPos;

    private void Awake()
    {
        _lazer = GetComponentInChildren<Lazer>();
    }

    public void LastPhaseAttack()
    {
        transform.DOMove(_lastPos.position,0.5f);
        StartCoroutine(LastAttack());
    }

    private IEnumerator LastAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            PoolManager.Instance.Pop("Plus");
            yield return new WaitForSeconds(0.4f);
            int rand = Random.Range(0, _rot.Length); 
            _lazer.ShotExpolmeArr(new[] { gameObject.transform},new[] { _rot[rand] },null);
            _lazer.ShootLazerArr(new[] { gameObject.transform }, new[] { _rot[rand] }, null);
            transform.DOScale(0, 7);

            if(transform.localScale.magnitude == 0)
            {
                GameManager.Instance.state = GameManager.TrunState.win;
                GameManager.Instance._EnemyTrunEnd = true;
                break;
            }
        }
    }
}
