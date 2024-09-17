using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProbelmsReader : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1dUTpj2FoPiGo1JKVeHw8iyc3zGqvFQukfNoA8TDTl6c/export?format=tsv&range=A2:F";

    IEnumerator Start()
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

    void ParseTSVData(string data)
    {
        // TSV 데이터를 줄 단위로 나누기
        string[] rows = data.Split('\n');

        foreach (string row in rows)
        {
            if (string.IsNullOrWhiteSpace(row)) continue;

            // 각 줄을 탭으로 구분하여 열 단위로 나누기
            string[] columns = row.Split('\t');

            if (columns.Length >= 6)
            {
                string question = columns[0];
                string option1 = columns[1];
                string option2 = columns[2];
                string option3 = columns[3];
                string option4 = columns[4];
                string answer = columns[5];

                Debug.Log($"Question: {question}");
                Debug.Log($"1. {option1}");
                Debug.Log($"2. {option2}");
                Debug.Log($"3. {option3}");
                Debug.Log($"4. {option4}");
                Debug.Log($"Answer: {answer}");
            }
        }
    }
}
