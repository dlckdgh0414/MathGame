using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathProblem : MonoBehaviour
{
    public MathProblemSO _mathProblemSO;

    public ProbelmsReader _problemReader;

    public List<GameObject> ControllButton = new List<GameObject>();
    public List<TextMeshProUGUI> ProblemText = new List<TextMeshProUGUI>();
    public TextMeshProUGUI problemName;

    public List<int> _resultNumber = new List<int>();

    public static int ProblemNumber = 0;
    private int _randomInt;

    private void OnEnable()
    {
        _randomInt = Random.Range(0, 4);
    }

    private void Start()
    {
    }


    private void Update()
    {
        if(ProbelmsReader._isComplete == true)
        {
            print(_mathProblemSO.ResultNumber[ProblemNumber]);

            switch (int.Parse(_mathProblemSO.ResultNumber[ProblemNumber]))
            {   
                case 1:
                    ControllButton[0].gameObject.TryGetComponent(out SelectMathButton Select);
                    Select._isGuess = true;
                    break;
                case 2:
                    ControllButton[1].gameObject.TryGetComponent(out SelectMathButton Select2);
                    Select2._isGuess = true;
                    break;
                case 3:
                    ControllButton[2].gameObject.TryGetComponent(out SelectMathButton Select3);
                    Select3._isGuess = true;
                    break;
                case 4:
                    ControllButton[3].gameObject.TryGetComponent(out SelectMathButton Select4);
                    Select4._isGuess = true;
                    break;
            }

            problemName.text = _mathProblemSO.Problem[ProblemNumber];
            ProblemText[0].text = _mathProblemSO.Choice1[ProblemNumber];
            ProblemText[1].text = _mathProblemSO.Choice2[ProblemNumber];
            ProblemText[2].text = _mathProblemSO.Choice3[ProblemNumber];
            ProblemText[3].text = _mathProblemSO.Choice4[ProblemNumber];
        }
    }

    private void LateUpdate()
    {
    }
}
