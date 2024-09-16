using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Question
{
    public string[] question;          // 문제 텍스트
    public string[] choices;     // 선택지 리스트
    public int answer;               // 정답 (선택지의 인덱스)
}

[Serializable]
public class QuestionList
{
    public List<Question> questions;  // 여러 문제를 담는 리스트
}

public class ProblemManager : MonoBehaviour
{
    public QuestionList questionList; // 여러 문제를 담는 QuestionList 객체

    void Start()
    {
        // JSON 파일 로드 및 파싱
        string jsonPath = Application.dataPath + "/questions.json";  // 외부 경로 예시
        if (System.IO.File.Exists(jsonPath))
        {
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            questionList = JsonUtility.FromJson<QuestionList>(jsonData);

            // 첫 번째 문제 출력
            Debug.Log("첫 번째 문제: " + questionList.questions[0].question);
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다.");
        }
    }
}
