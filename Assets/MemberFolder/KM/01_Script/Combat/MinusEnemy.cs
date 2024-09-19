using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MinusEnemy : MonoBehaviour
{
    private int Count;
    public Pooling enemy;
    public EnemyStatsSo enemyStat;

    private Image _image;
    private Sequence seq;

    private void Awake()
    {
        _image = GetComponent<Image>();
        seq = DOTween.Sequence();
    }

    public void MinusRain()
    {
        StartCoroutine(EnemyAttackSkill());

        seq.Append(_image.rectTransform.DOAnchorPosX(100, 1f)
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo));
    }

    private IEnumerator EnemyAttackSkill()
    {
        for (int i = 0; i < Count; i++)
        {
            enemy = PoolManager.Instance.Pop("PlusAttack") as Pooling;

            if (enemy != null)
                enemy.gameObject.transform.position = transform.position;

            yield return new WaitForSeconds(enemyStat.AttackDuration / Count);
        }
    }
}