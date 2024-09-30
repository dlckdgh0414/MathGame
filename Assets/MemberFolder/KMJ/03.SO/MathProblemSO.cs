using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "MathProblem/SO")]
public class MathProblemSO : ScriptableObject
{
    public List<string> Problem;

    public List<string> Choice1;

    public List<string> Choice2;

    public List<string> Choice3;

    public List<string> Choice4;

    public List<string> ResultNumber;
}
