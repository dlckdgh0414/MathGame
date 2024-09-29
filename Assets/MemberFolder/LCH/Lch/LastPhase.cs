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
    public Pooling enemy;
    public Pooling enemy2;

    private void Awake()
    {
        _lazer = GetComponentInChildren<Lazer>();
    }

    public void LastPhaseAttack()
    {
        transform.DOMoveY(_lastPos.position.y,0.5f);
        StartCoroutine(LastAttack());
    }

    private IEnumerator LastAttack()
    {
        transform.DOScale(1,0.5f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            enemy = PoolManager.Instance.Pop("PlusAttack") as Pooling;
            enemy2 = PoolManager.Instance.Pop("Minus") as Pooling;
            if(enemy2 != null)
            {
                gameObject.transform.position = transform.position;
            }
            if(enemy != null)
            {
                gameObject.transform.position = transform.position;
            }
            yield return new WaitForSeconds(0.4f);
            int rand = Random.Range(0, _rot.Length); 
            _lazer.ShotExpolmeArr(new[] { gameObject.transform},new[] { _rot[rand] },null);
            _lazer.ShootLazerArr(new[] { gameObject.transform }, new[] { _rot[rand] }, null);
            transform.DOScale(0, 7);

            if (transform.localScale.magnitude < 0.1f)
            {
                Destroy(gameObject);
                GameManager.Instance.state = GameManager.TrunState.win;
                GameManager.Instance._EnemyTrunEnd = true;
            }
        }
    }
}
