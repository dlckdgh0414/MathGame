using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProbelmsReader : MonoBehaviour
{
    public string fileName = "Problems.csv"; // CSV ���� �̸�

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
        // ���ø����̼��� ���� ���丮 ��θ� �����ɴϴ�.
        string filePath = Path.Combine(Application.dataPath, fileName);
        Debug.Log("CSV ���� ���: " + filePath);

        // CSV ���� �ε�
        LoadCSV(filePath);
    }

    void LoadCSV(string filePath)
    {
        if (File.Exists(filePath))
        {
            // CSV ������ ��� ���� ����
            string[] rows = File.ReadAllLines(filePath);

            // ù ���� ����̹Ƿ� �ǳʶ�
            for (int i = 1; i < rows.Length; i++)
            {
                // �� ���� ��ǥ�� ������ �ʵ�� �и�
                string[] fields = rows[i].Split(',');

                // Quiz ��ü�� �����͸� ����
                Quiz quiz = new Quiz();
                quiz.problem = fields[0];
                quiz.choice1 = fields[1];
                quiz.choice2 = fields[2];
                quiz.choice3 = fields[3];
                quiz.choice4 = fields[4];
                quiz.resultNumber = int.Parse(fields[5]);

                // ���� ����Ʈ�� �߰�
                quizList.Add(quiz);
            }

            // ���� �����͸� �ֿܼ� ��� (����׿�)
            foreach (var q in quizList)
            {
                Debug.Log($"����: {q.problem}, ������: {q.choice1}, {q.choice2}, {q.choice3}, {q.choice4}, ����: {q.resultNumber}");
            }
        }
        else
        {
            Debug.LogError("CSV ������ ã�� �� �����ϴ�: " + filePath);
        }
    }
}
