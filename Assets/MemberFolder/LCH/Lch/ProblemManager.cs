using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Question
{
    public string[] question;          // ���� �ؽ�Ʈ
    public string[] choices;     // ������ ����Ʈ
    public int answer;               // ���� (�������� �ε���)
}

[Serializable]
public class QuestionList
{
    public List<Question> questions;  // ���� ������ ��� ����Ʈ
}

public class ProblemManager : MonoBehaviour
{
    public QuestionList questionList; // ���� ������ ��� QuestionList ��ü

    void Start()
    {
        // JSON ���� �ε� �� �Ľ�
        string jsonPath = Application.dataPath + "/questions.json";  // �ܺ� ��� ����
        if (System.IO.File.Exists(jsonPath))
        {
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            questionList = JsonUtility.FromJson<QuestionList>(jsonData);

            // ù ��° ���� ���
            Debug.Log("ù ��° ����: " + questionList.questions[0].question);
        }
        else
        {
            Debug.LogError("JSON ������ ã�� �� �����ϴ�.");
        }
    }
}
