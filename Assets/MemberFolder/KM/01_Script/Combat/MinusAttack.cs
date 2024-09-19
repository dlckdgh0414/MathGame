using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MinusAttack : MonoBehaviour
{
    private Image _enemy;
    private Sequence seq;
    public Pooling enemy;

    private bool notAttackTime = false;
    private float _currentTime, _coolTime;

    public EnemyStatsSo _currentStat;

    private void Awake()
    {
        _enemy = GameObject.Find("Enemy").GetComponent<Image>();
        seq = DOTween.Sequence();
    }

    public void MinusAttack01()
    {
        StartCoroutine(AttackDurationRoutine());

        seq.Append(_enemy.rectTransform.DOAnchorPosX(200, 1f)
            .SetEase(Ease.InOutCubic))
            .Append(_enemy.rectTransform.DOAnchorPosX(-200, 1f)
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo));
    }

    private IEnumerator AttackDurationRoutine()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(_currentStat.AttackDuration / 15);
            enemy = PoolManager.Instance.Pop("Minus") as Pooling;

            if (enemy != null)
            {
                enemy.gameObject.transform.position = _enemy.transform.position;
            }
        }
        notAttackTime = true;
    }
}
