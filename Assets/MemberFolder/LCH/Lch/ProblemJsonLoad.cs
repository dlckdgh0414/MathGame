using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProblemJsonLoad : MonoBehaviour
{
    public QuestionList questionList;

    string sourcePath;
    string targetPath;

    void Start()
    {
        sourcePath = Application.persistentDataPath + "/questions.json";
        targetPath = Application.dataPath + "/questions.json";
        Debug.Log("StreamingAssets Path: " + Application.streamingAssetsPath);
        // ���� ���� ������ �ִ� ��ο� JSON ���� ����
        // ������ ������ ������ �ҷ���
        Debug.Log("JSON ���� ���� ���: " + targetPath); Debug.Log("Source Path: " + sourcePath);
        Debug.Log("Target Path: " + targetPath);
        LoadJSONFile();

    }

    void LoadJSONFile()
    {
        if (File.Exists(targetPath))
        {
            // ���Ͽ��� JSON �����͸� �о��
            string jsonData = File.ReadAllText(targetPath);
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
