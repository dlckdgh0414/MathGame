using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MinusAttack : MonoBehaviour
{
    private Image _enemy;
    private Sequence seq;
    private Pooling enemy;

    public EnemyStatsSo _currentStat;

    private void Awake()
    {
        _enemy = GameObject.Find("Enemy").GetComponent<Image>();
        seq = DOTween.Sequence();
    }

    public void MinusAttack01()
    {
        StartCoroutine(AttackDurationRoutine());

        _enemy.rectTransform.DOAnchorPosX(-300, 1f)
           .SetEase(Ease.InOutCubic).OnComplete(() =>
           {
               seq.Append(_enemy.rectTransform.DOAnchorPosX(300, 2f)
                  .SetEase(Ease.InOutCubic)
                  .SetLoops(5, LoopType.Yoyo));
           });
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

            StartCoroutine(PushEnemy(enemy));
        }

        _enemy.rectTransform.DOAnchorPosX(0, 1f);
    }

    private IEnumerator PushEnemy(Pooling pool)
    {
        yield return new WaitForSeconds(_currentStat.AttackDuration);
        PoolManager.Instance.Push(pool);
    }
}
