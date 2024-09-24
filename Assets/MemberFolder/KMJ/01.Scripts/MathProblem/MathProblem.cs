using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathProblem : MonoBehaviour
{
    public MathProblemSO _mathProblemSO;

    public List<GameObject> ControllButton = new List<GameObject>();
    public List<TextMeshProUGUI> ProblemText = new List<TextMeshProUGUI>();
    public TextMeshProUGUI problemName;

    public static int ProblemNumber = 0;
    private int _randomInt;

    private void OnEnable()
    {
        _randomInt = Random.Range(0, 4);
        Debug.Log(_randomInt);
    }
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {

    }


    private void Update()
    {
        switch(_mathProblemSO.ResultNumber[ProblemNumber])
        {
            case "1":
                ControllButton[0].gameObject.TryGetComponent(out SelectMathButton Select);
                Select._isGuess = true;
                break;
            case "2":
                ControllButton[1].gameObject.TryGetComponent(out SelectMathButton Select2);
                Select2._isGuess = true;
                break;
            case "3":
                ControllButton[2].gameObject.TryGetComponent(out SelectMathButton Select3);
                Select3._isGuess = true;
                break;
            case "4":
                ControllButton[3].gameObject.TryGetComponent(out SelectMathButton Select4);
                Select4._isGuess = true;
                break;
            default:
                break;
        }

        problemName.text = _mathProblemSO.Problem[ProblemNumber];
        ProblemText[0].text = _mathProblemSO.Choice1[ProblemNumber];
        ProblemText[1].text = _mathProblemSO.Choice2[ProblemNumber];
        ProblemText[2].text = _mathProblemSO.Choice3[ProblemNumber];
        ProblemText[3].text = _mathProblemSO.Choice4[ProblemNumber];

        
    }
}
