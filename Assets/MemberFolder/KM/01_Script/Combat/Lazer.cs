using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Lazer : MonoBehaviour
{
    public Pooling lazer;
    public Pooling lazerex;
    private SpriteRenderer _lazerSprite;
    private SpriteRenderer _lazerSpriteex;
    private Sequence seq;

    public void ShotExpolmeArr(Transform[] pos, Quaternion[] rot, Transform root)
    {
        for (int i = 0; i < pos.Length; i++)
        {
            lazerex = PoolManager.Instance.Pop("LazerEX") as Pooling;
            lazerex.transform.SetParent(root);
            _lazerSpriteex = lazerex.GetComponent<SpriteRenderer>();
            seq = DOTween.Sequence();

            if (lazerex != null)
            {
                lazerex.gameObject.transform.position = pos[i].position;
                lazerex.transform.rotation = rot[i];
                lazerex.transform.localScale = new Vector3(0, lazerex.transform.localScale.y);
            }

            seq.Append(lazerex.transform.DOScaleX(1, 0.5f))
                .Append(lazerex.transform.DOScaleX(0, 0.25f));
        }
    }

    public void ShootLazerArr(Transform[] pos, Quaternion[] rot, Transform root)
    {
        for(int i = 0; i < pos.Length; i++)
        {
            lazer = PoolManager.Instance.Pop("Lazer") as Pooling;
            lazer.transform.SetParent(root);
            _lazerSprite = lazer.GetComponent<SpriteRenderer>();
            seq = DOTween.Sequence();

            if (lazer != null)
            {
                lazer.gameObject.transform.position = pos[i].position;
                lazer.transform.rotation = rot[i];
                lazer.transform.localScale = new Vector3(0, lazer.transform.localScale.y);
            }

            seq.Append(lazer.transform.DOScaleX(1, 0.5f)
                .SetEase(Ease.OutElastic))
                .Append(lazer.transform.DOScaleX(0, 0.25f));
        }
    }
}
