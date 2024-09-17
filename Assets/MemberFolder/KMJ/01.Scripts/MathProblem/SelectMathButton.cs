using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMathButton : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _mathProblem;
    public void SelectCollect()
    {
        MathProblem.ProblemNumber += 1;
        _timeSlider.value = 20;
        _mathProblem.SetActive(false);
    }

    public void SelectFalse()
    {
        _timeSlider.value = 20;
        _mathProblem.SetActive(false);
    }
}
