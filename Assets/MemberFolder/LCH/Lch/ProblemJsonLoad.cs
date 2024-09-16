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
        sourcePath = Application.dataPath + "/questions.json";
        targetPath = Application.dataPath + "/questions.json";
        Debug.Log("StreamingAssets Path: " + Application.streamingAssetsPath);
        Debug.Log("JSON 파일 저장 경로: " + targetPath); Debug.Log("Source Path: " + sourcePath);
        Debug.Log("Target Path: " + targetPath);
        LoadJSONFile();

    }

    void LoadJSONFile()
    {
        if (File.Exists(targetPath))
        {
            // 파일에서 JSON 데이터를 읽어옴
            string jsonData = File.ReadAllText(targetPath);
            questionList = JsonUtility.FromJson<QuestionList>(jsonData);
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다.");
        }
    }
}
