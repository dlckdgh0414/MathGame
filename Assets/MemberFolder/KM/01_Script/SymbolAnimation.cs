using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SymbolAnimation : MonoBehaviour
{
    [SerializeField] private float maxRotate = 10;
    [SerializeField] private float moveTime = 2;

    private Sequence seq;

    private void Awake()
    {
        seq = DOTween.Sequence();
    }

    private void Start()
    {
        RotateAnim();
    }

    private void RotateAnim()
    {
        seq.Append(transform
            .DORotate(new Vector3(0, 0, -maxRotate), moveTime)
            .SetEase(Ease.InOutSine))
            .SetLoops(-1, LoopType.Yoyo);
    }
}
