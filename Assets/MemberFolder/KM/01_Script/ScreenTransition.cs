using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ScreenTransition : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;

    public event Action OnSceneTransition;

    private float startValue = 0, endValue = 2;
    private Sequence _seq;

    private void Awake()
    {
        _seq = DOTween.Sequence();
    }

    public void Transition()
    {
        DOTween.To(() => endValue, end =>
        _transitionImage.material.SetFloat("_Strength", end), startValue, 0.7f)
            .OnComplete(() =>
            {
                OnSceneTransition?.Invoke();
                DOTween.To(() => startValue, end =>
                    _transitionImage.material.SetFloat("_Strength", end), endValue, 3f);
            });
    }
}
