using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathProblem : MonoBehaviour
{
    public List<TextMeshProUGUI> problemAnswer = new List<TextMeshProUGUI>();
    public List<Button> _problemButton = new List<Button>();

    private int _randomInt;


    private void Awake()
    {
        _randomInt = Random.Range(0,5);
    }
    private void Start()
    {
        
    }


    private void Update()
    {

    }
}
