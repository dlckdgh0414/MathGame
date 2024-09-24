using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMathButton : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _mathProblem;
    [field : SerializeField] public bool _isGuess { get; set; }
    private int _damage;
    private GameObject _enemy;


    public void SelectCollect()
    {
        if (_isGuess == true)
        {
            if (_timeSlider.value >= 10)
                _damage += 3;

            else if (_timeSlider.value < 10 && _timeSlider.value >= 5)
                _damage += 3;

            else
            {
                _damage = 5;
            }

            Health enemy = GameObject.FindWithTag("Enemy").GetComponent<Health>();

            enemy.MinusDamage(_damage);

            MathProblem.ProblemNumber += 1;
            _damage = 0;
            _timeSlider.value = 20;
            GameManager._isFinish = false;
            _mathProblem.SetActive(false);
        }
    }

    public void SelectFalse()
    {
        if (_isGuess == false)
        {
            _timeSlider.value = 20;
            GameManager._isFinish = true;
            _mathProblem.SetActive(false);
        }
    }
}
