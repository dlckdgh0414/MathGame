using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ProbelmsReader : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1dUTpj2FoPiGo1JKVeHw8iyc3zGqvFQukfNoA8TDTl6c/export?format=tsv&range=A2:F    ";
    [SerializeField] private MathProblemSO _mathProblemSO;
    public static bool _isComplete;

    private IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            string data = www.downloadHandler.text;
            ParseTSVData(data);
        }
    }

    private void OnDisable()
    {
        _mathProblemSO.Problem.Clear();
        _mathProblemSO.Choice1.Clear();
        _mathProblemSO.Choice2.Clear();
        _mathProblemSO.Choice3.Clear();
        _mathProblemSO.Choice4.Clear();
        _mathProblemSO.ResultNumber.Clear();
    }
    void ParseTSVData(string data)
    {
        // TSV 데이터를 줄 단위로 나누기
        string[] rows = data.Split('\n');

        foreach (string row in rows)
        {
            if (string.IsNullOrWhiteSpace(row)) continue;

            string[] columns = row.Split('\t');

            _mathProblemSO.Problem.Add(columns[0]);
            _mathProblemSO.Choice1.Add(columns[1]);
            _mathProblemSO.Choice2.Add(columns[2]);
            _mathProblemSO.Choice3.Add(columns[3]);
            _mathProblemSO.Choice4.Add(columns[4]);
            _mathProblemSO.ResultNumber.Add(columns[5]);

            _isComplete = true;

        }
    }

    
}
