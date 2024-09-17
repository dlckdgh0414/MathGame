using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProbelmsReader : MonoBehaviour
{
    public string fileName = "Problems.csv"; // CSV 파일 이름

    [System.Serializable]
    public class Quiz
    {
        public string problem;
        public string choice1;
        public string choice2;
        public string choice3;
        public string choice4;
        public int resultNumber;
    }

    public List<Quiz> quizList = new List<Quiz>();

    void Start()
    {
        // 애플리케이션의 실행 디렉토리 경로를 가져옵니다.
        string filePath = Path.Combine(Application.dataPath, fileName);
        Debug.Log("CSV 파일 경로: " + filePath);

        // CSV 파일 로드
        LoadCSV(filePath);
    }

    void LoadCSV(string filePath)
    {
        if (File.Exists(filePath))
        {
            // CSV 파일의 모든 줄을 읽음
            string[] rows = File.ReadAllLines(filePath);

            // 첫 줄은 헤더이므로 건너뜀
            for (int i = 1; i < rows.Length; i++)
            {
                // 각 줄을 쉼표로 나누어 필드로 분리
                string[] fields = rows[i].Split(',');

                // Quiz 객체에 데이터를 담음
                Quiz quiz = new Quiz();
                quiz.problem = fields[0];
                quiz.choice1 = fields[1];
                quiz.choice2 = fields[2];
                quiz.choice3 = fields[3];
                quiz.choice4 = fields[4];
                quiz.resultNumber = int.Parse(fields[5]);

                // 퀴즈 리스트에 추가
                quizList.Add(quiz);
            }

            // 퀴즈 데이터를 콘솔에 출력 (디버그용)
            foreach (var q in quizList)
            {
                Debug.Log($"문제: {q.problem}, 선택지: {q.choice1}, {q.choice2}, {q.choice3}, {q.choice4}, 정답: {q.resultNumber}");
            }
        }
        else
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다: " + filePath);
        }
    }
}
