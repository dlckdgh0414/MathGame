using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathProblem : MonoBehaviour
{
    public ProblemFile problemfile;

    public List<TextMeshProUGUI> ProblemText;
    public TextMeshProUGUI problemName;

    public static int ProblemNumber = 0;
    private int _randomInt;

    private void OnEnable()
    {
        _randomInt = Random.Range(0, 5);
        Debug.Log(_randomInt);
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
    }


    private void Update()
    {      
        problemName.text = problemfile.Problems[ProblemNumber].Problem;
        ProblemText[0].text = problemfile.Problems[ProblemNumber].Choice1;
        ProblemText[1].text = problemfile.Problems[ProblemNumber].Choice2;
        ProblemText[2].text = problemfile.Problems[ProblemNumber].Choice3;
        ProblemText[3].text = problemfile.Problems[ProblemNumber].Choice4;
    }
}
